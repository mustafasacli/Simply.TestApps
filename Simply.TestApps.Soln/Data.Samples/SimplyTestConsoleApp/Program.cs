using MySql.Data.MySqlClient;
using Simply.Data;
using Simply.Data.Interfaces;
using Simply.Data.Objects;
using Simply_Test_Db;
using System;
using System.Data;
using System.Linq;

namespace SimplyTestConsoleApp
{
    internal class Program
    {
        internal static IDbConnection GetDbConnection()
        {
            return new MySqlConnection { ConnectionString = "data source=127.0.0.1;initial catalog=classicmodels;user id=root;" };
        }

        private static void Main(string[] args)
        {
            // TODO : DONE. ANY METHODS TEST PASSED.
            bool exist;
            int id = 100;
            ISimpleDatabase database = new SimpleMySqlDatabase();
            exist = database.Any("select * from customers where customerNumber < @id", new { id });
            if (!exist)
            {
                Console.WriteLine($"***There no record for less than {id}.");
            }
            else
            {
                Console.WriteLine($"***There is one record at least for less than {id}.");
            }

            exist = database.Any("select * from customers where customerNumber < ?id?", new { id },
                SimpleCommandSetting.Create(parameterNamePrefix: '?'));
            if (!exist)
            {
                Console.WriteLine($"**There no record for less than {id}.");
            }
            else
            {
                Console.WriteLine($"**There is one record at least for less than {id}.");
            }

            exist = database.AnyOdbc("select * from customers where customerNumber < ?", new[] { (object)id });
            if (!exist)
            {
                Console.WriteLine($"**There no record for less than {id}.");
            }
            else
            {
                Console.WriteLine($"**There is one record at least for less than {id}.");
            }

            exist = database.AnyJdbc("select * from customers where customerNumber < ?1", new[] { (object)id });
            if (!exist)
            {
                Console.WriteLine($"**There no record for less than {id}.");
            }
            else
            {
                Console.WriteLine($"**There is one record at least for less than {id}.");
            }

            exist = database.Any("select * from customers where customerNumber >= @id", new { id });

            if (exist)
            {
                Console.WriteLine($"There is one record at least for greater or equal than {id}.");
            }
            else
            {
                Console.WriteLine($"There no record for greater or equal than {id}.");
            }

            exist = database.Any("select * from customers where customerNumber >= ?id?", new { id },
                SimpleCommandSetting.Create(parameterNamePrefix: '?'));

            if (exist)
            {
                Console.WriteLine($"There is one record at least for greater or equal than {id}.");
            }
            else
            {
                Console.WriteLine($"There no record for greater or equal than {id}.");
            }

            exist = database.AnyOdbc("select * from customers where customerNumber >= ?", new[] { (object)id });

            if (exist)
            {
                Console.WriteLine($"There is one record at least for greater or equal than {id}.");
            }
            else
            {
                Console.WriteLine($"There no record for greater or equal than {id}.");
            }

            SimpleDbCommand simpleDbCommand = new SimpleDbCommand()
            {
                CommandType = CommandType.Text,
                CommandText = "select * from customers where customerNumber < @id"
            };
            simpleDbCommand.AddParameter(new DbCommandParameter { ParameterName = "id", Value = id });
            exist = database.Any(simpleDbCommand);
            if (!exist)
            {
                Console.WriteLine($"There no record for less than {id}.");
            }
            else
            {
                Console.WriteLine($"There is one record at least for less than {id}.");
            }
            simpleDbCommand.CommandText = "select * from customers where customerNumber >= @id";
            exist = database.Any(simpleDbCommand);
            if (exist)
            {
                Console.WriteLine($"There is one record at least for greater or equal than {id}.");
            }
            else
            {
                Console.WriteLine($"There no record for greater or equal than {id}.");
            }

            Console.ReadKey();
        }
    }
}