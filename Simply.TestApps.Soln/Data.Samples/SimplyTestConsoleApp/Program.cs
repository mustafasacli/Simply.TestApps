﻿using MySql.Data.MySqlClient;
using Simply.Data;
using Simply.Data.Objects;
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
            bool exist = false;
            int id = 100;
            using (IDbConnection connection = GetDbConnection())
            {
                connection.OpenIfNot();
                exist = connection.Any("select * from customers where customerNumber < @id", new { id });
            }
            if (!exist)
            {
                Console.WriteLine($"There no record for less than {id}.");
            }
            else
            {
                Console.WriteLine($"There is one record at least for less than {id}.");
            }
            using (IDbConnection connection = GetDbConnection())
            {
                connection.OpenIfNot();
                exist = connection.Any("select * from customers where customerNumber >= @id", new { id });
            }
            if (exist)
            {
                Console.WriteLine($"There is one record at least for greater or equal than {id}.");
            }
            else
            {
                Console.WriteLine($"There no record for greater or equal than {id}.");
            }
            Console.WriteLine("-----------------------------------------");
            using (IDbConnection connection = GetDbConnection())
            {
                connection.OpenIfNot();
                exist = connection.Any("select * from customers where customerNumber < ?", new object[] { id });
            }
            if (!exist)
            {
                Console.WriteLine($"There no record for less than {id}.");
            }
            else
            {
                Console.WriteLine($"There is one record at least for less than {id}.");
            }
            using (IDbConnection connection = GetDbConnection())
            {
                connection.OpenIfNot();
                exist = connection.Any("select * from customers where customerNumber >= ?", new object[] { id });
            }
            if (exist)
            {
                Console.WriteLine($"There is one record at least for greater or equal than {id}.");
            }
            else
            {
                Console.WriteLine($"There no record for greater or equal than {id}.");
            }
            Console.WriteLine("-----------------------------------------");
            DbCommandDefinition commandDefinition = new DbCommandDefinition();
            commandDefinition.CommandType = CommandType.Text;
            commandDefinition.CommandText = "select * from customers where customerNumber < @id";
            commandDefinition.AddParameter(new DbCommandParameter { ParameterName = "id", Value = id });
            using (IDbConnection connection = GetDbConnection())
            {
                connection.OpenIfNot();
                exist = connection.Any(commandDefinition);
            }
            if (!exist)
            {
                Console.WriteLine($"There no record for less than {id}.");
            }
            else
            {
                Console.WriteLine($"There is one record at least for less than {id}.");
            }

            commandDefinition.CommandText = "select * from customers where customerNumber >= @id";
            using (IDbConnection connection = GetDbConnection())
            {
                connection.OpenIfNot();
                exist = connection.Any(commandDefinition);
            }
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