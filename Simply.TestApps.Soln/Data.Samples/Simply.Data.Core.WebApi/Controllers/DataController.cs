using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MySql.Data.MySqlClient;
using Simply.Data.Objects;
using SimplyTest_Entities;
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
        public IEnumerable<Customers> Get(int? customerNumber)
        {
            _logger.LogInformation("customerNumber:#{0}#", customerNumber);

            IEnumerable<Customers> customers;

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

            return customers;
        }
    }
}
