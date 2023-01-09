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
        private readonly ISimpleDatabase database1;

        public CustomerController(ILogger<CustomerController> logger, ISimpleDatabase database)
        {
            _logger = logger;
            database1 = database;
        }

        [HttpGet]
        public IEnumerable<CustomersDto> Get(int? customerNumber)
        {
            _logger.LogInformation("customerNumber:#{0}#", customerNumber);

            List<Customers> customers = database1.List<Customers>(
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
            database1.Begin();
            object objCustomerNumber = database1.ExecuteScalar("SELECT MAX(`customerNumber`) FROM `classicmodels`.`customers`",
                                        null, commandSetting: null);
            model.CustomerNumber = (objCustomerNumber.ToIntNullable() ?? 0) + 1;
            response.ResponseCode = database1.Execute(strSql, model, commandSetting: SimpleCommandSetting.Create(parameterNamePrefix: '?'));
            database1.Commit();

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
            database1.Begin();
            response.ResponseCode = database1.Execute(strSql,
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
            database1.Commit();

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
            database1.Begin();

            int reposnseCode = database1.Execute(strSql,
                           new
                           {
                               customerNumber
                           }, commandSetting: SimpleCommandSetting.Create(parameterNamePrefix: '?'));
            database1.Commit();

            return SimpleResponse.New(reposnseCode);
        }
    }
}