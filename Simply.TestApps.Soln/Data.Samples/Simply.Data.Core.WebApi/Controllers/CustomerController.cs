using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mst.Project.Dtos;
using Mst.Project.ViewModel;
using SimpleInfra.Common.Response;
using SimpleInfra.Mapping;
using SimpleInfra.Validation;
using Simply.Common;
using Simply.Data.Interfaces;
using Simply.Data.Objects;
using SimplyTest_Entities;
using System.Collections.Generic;

namespace Simply.Data.Core.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ILogger<CustomerController> _logger;
        private readonly ISimpleDatabase dbInstance;

        public CustomerController(ILogger<CustomerController> logger, ISimpleDatabase database)
        {
            _logger = logger;
            dbInstance = database;
        }

        [HttpGet]
        public IEnumerable<CustomersDto> Get(int? customerNumber)
        {
            _logger.LogInformation("customerNumber:#{0}#", customerNumber);

            List<Customers> customers = dbInstance.List<Customers>(
                "SELECT * FROM `classicmodels`.`customers` WHERE `customerNumber` = ?customerNumber? or ?customerNumber? is null",
                        new { customerNumber }, commandSetting: SimpleCommandSetting.Create(parameterNamePrefix: '?'));

            return SimpleMapper.MapList<Customers, CustomersDto>(customers);
        }

        [HttpPost]
        public SimpleResponse<CustomersViewModel> Create([FromBody] CustomersViewModel model)
        {
            SimpleResponse<CustomersViewModel> response = new SimpleResponse<CustomersViewModel>();

            var validationResult = model.Validate();
            if (validationResult.HasError)
            {
                response.Data = model;
                response.ResponseMessage = validationResult.AllValidationMessages;
                response.ResponseCode = -200;
                return response;
            }

            string strSql = @"INSERT INTO classicmodels.customers
(customerNumber, customerName, contactLastName, contactFirstName, phone, addressLine1, addressLine2, city, state, postalCode, country, salesRepEmployeeNumber, creditLimit)
VALUES(?CustomerNumber?, ?CustomerName?, ?ContactLastName?, ?ContactFirstName?, ?Phone?, ?AddressLine1?, ?AddressLine2?, ?City?, ?State?, ?PostalCode?, ?Country?, ?SalesRepEmployeeNumber?, ?CreditLimit?);";
            //; SELECT CAST(LAST_INSERT_ID() AS SIGNED);
            dbInstance.Begin();
            object objCustomerNumber = dbInstance.ExecuteScalar("SELECT MAX(`customerNumber`) FROM `classicmodels`.`customers`",
                                        null, commandSetting: null);
            // model.CustomerNumber = dbInstance.ExecuteScalarAs<int>("SELECT MAX(`customerNumber`) as max FROM `classicmodels`.`customers`", null, null);
            model.CustomerNumber = (objCustomerNumber.ToIntNullable() ?? 0) + 1;
            response.ResponseCode = dbInstance.Execute(strSql, model, commandSetting: SimpleCommandSetting.Create(parameterNamePrefix: '?'));
            dbInstance.Commit();

            response.Data = model;
            return response;
        }

        [HttpPut]
        public SimpleResponse<CustomersViewModel> Update([FromBody] CustomersViewModel model)
        {
            SimpleResponse<CustomersViewModel> response = new SimpleResponse<CustomersViewModel>();

            var validationResult = model.Validate();
            if (validationResult.HasError)
            {
                response.Data = model;
                response.ResponseMessage = validationResult.AllValidationMessages;
                response.ResponseCode = -200;
                return response;
            }

            string strSql = @"update classicmodels.customers
set customerName=?CustomerName?, contactLastName=?ContactLastName?,
contactFirstName=?ContactFirstName?, phone=?Phone?, addressLine1=?AddressLine1?, addressLine2=?AddressLine2?,
city=?City?, state=?State?, postalCode=?PostalCode?, country=?Country?, salesRepEmployeeNumber=?SalesRepEmployeeNumber?, creditLimit=?CreditLimit?
where customerNumber=?CustomerNumber?;";
            dbInstance.Begin();
            response.ResponseCode = dbInstance.Execute(strSql,
                            new
                            {
                                model.CustomerName,
                                model.ContactLastName,
                                model.ContactFirstName,
                                model.Phone,
                                model.AddressLine1,
                                model.AddressLine2,
                                model.City,
                                model.State,
                                model.PostalCode,
                                model.Country,
                                model.SalesRepEmployeeNumber,
                                model.CreditLimit,
                                model.CustomerNumber
                            }, commandSetting: SimpleCommandSetting.Create(parameterNamePrefix: '?'));
            dbInstance.Commit();

            response.Data = model;
            return response;
        }

        [HttpDelete]
        public SimpleResponse Delete(int? customerNumber)
        {
            _logger.LogInformation("customerNumber:#{0}#", customerNumber);

            if ((customerNumber ?? 0) < 1)
                return SimpleResponse.New(responseCode: -1);

            string strSql = "DELETE FROM `classicmodels`.`customers` WHERE `customerNumber` = ?customerNumber?";
            dbInstance.Begin();

            int reposnseCode = dbInstance.Execute(strSql,
                           new
                           {
                               customerNumber
                           }, commandSetting: SimpleCommandSetting.Create(parameterNamePrefix: '?'));
            dbInstance.Commit();

            return SimpleResponse.New(reposnseCode);
        }
    }
}