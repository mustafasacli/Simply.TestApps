using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MySql.Data.MySqlClient;
using Simply.Data.Objects;
using SimplyTest_Entities;
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
        private readonly ILogger<WeatherForecastController> _logger;

        public DataController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public Customers Get(int? customerNumber)
        {
            _logger.LogInformation("customerNumber:#{0}#", customerNumber);

            Customers customers;

            using (IDbConnection connection = GetDbConnection())
            {
                try
                {
                    customers = connection.OpenAnd()
                        .QuerySingle<Customers>("SELECT * FROM `classicmodels`.`customers` WHERE `customerNumber` = ?customerNumber?",
                        new { customerNumber }, commandSetting: SimpleCommandSetting.Create().SetParameterNamePrefix('?'));
                }
                finally
                { connection.CloseIfNot(); }
            }

            return customers;
        }
    }
}
