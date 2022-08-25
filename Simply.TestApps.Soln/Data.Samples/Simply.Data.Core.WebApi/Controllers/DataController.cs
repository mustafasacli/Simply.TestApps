using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mst.Project.Dtos;
using Mst.Project.ViewModel;
using MySql.Data.MySqlClient;
using SimpleInfra.Common.Response;
using SimpleInfra.Mapping;
using SimpleInfra.Validation;
using Simply.Common;
using Simply.Data.Objects;
using SimplyTest_Entities;
using System;
using System.Collections.Generic;
using System.Data;

namespace Simply.Data.Core.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DataController : ControllerBase
    {
        internal static IDbConnection GetDbConnection()
        {
            return new MySqlConnection { ConnectionString = "data source=127.0.0.1;initial catalog=classicmodels;user id=root;" };
        }

        private readonly ILogger<DataController> _logger;

        public DataController(ILogger<DataController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<CustomersDto> Get(int? customerNumber)
        {
            _logger.LogInformation("customerNumber:#{0}#", customerNumber);

            List<Customers> customers;

            using (IDbConnection connection = GetDbConnection())
            {
                try
                {
                    customers = connection.OpenAnd()
                        .QueryList<Customers>("SELECT * FROM `classicmodels`.`customers` WHERE `customerNumber` = ?customerNumber? or ?customerNumber? is null",
                        new { customerNumber }, commandSetting: SimpleCommandSetting.Create(parameterNamePrefix: '?'));
                }
                finally
                { connection.CloseIfNot(); }
            }

            return SimpleMapper.MapList<Customers, CustomersDto>(customers);
        }

        [HttpPost]
        public SimpleResponse<CustomersViewModel> Create(CustomersViewModel model)
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

            using (IDbConnection connection = GetDbConnection())
            using (IDbTransaction transaction = connection.OpenAndBeginTransaction())
            {
                try
                {
                    try
                    {
                        object objCustomerNumber = connection.OpenAnd()
                                        .ExecuteScalar("SELECT MAX(`customerNumber`) FROM `classicmodels`.`customers`",
                                        null, transaction, commandSetting: null);
                        model.CustomerNumber = (objCustomerNumber.ToIntNullable() ?? 0) + 1;
                        response.ResponseCode = connection.Execute(strSql, model, transaction,
                            commandSetting: SimpleCommandSetting.Create(parameterNamePrefix: '?'));
                        transaction?.Commit();
                    }
                    catch (Exception)
                    {
                        transaction?.Rollback();
                        throw;
                    }
                }
                finally
                { connection.CloseIfNot(); }
            }

            response.Data = model;
            return response;
        }
    }
}