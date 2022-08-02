using MySql.Data.MySqlClient;
using Simply.Data;
using Simply.Data.ConnectionExtensions;
using Simply.Data.Objects;
using System;
using System.Data;

namespace SimplyTest_Count_ConsoleApp
{
    internal class Program
    {
        internal static IDbConnection GetDbConnection()
        {
            return new MySqlConnection { ConnectionString = "data source=127.0.0.1;initial catalog=classicmodels;user id=root;" };
        }

        private static void Main(string[] args)
        {
            int orderNumber = 10100;
            using (IDbConnection connection = GetDbConnection())
            {
                try
                {
                    connection.OpenIfNot();
                    long result = connection.CountLong("select * from `classicmodels`.`orderdetails` where `orderNumber` = @orderNumber", new { orderNumber });
                    Console.WriteLine(result == 4 ? "4 kayıt bulundu." : $"Hatalı sonuç. {result} kayıt bulundu. ");
                }
                finally
                { connection.CloseIfNot(); }
            }
            Console.WriteLine("--------------------------------------------------------");

            using (IDbConnection connection = GetDbConnection())
            {
                try
                {
                    connection.OpenIfNot();
                    long result = connection.CountLong("select * from `classicmodels`.`orderdetails` where `orderNumber` = ?", new object[] { orderNumber });
                    Console.WriteLine(result == 4 ? "4 kayıt bulundu." : $"Hatalı sonuç. {result} kayıt bulundu. ");
                }
                finally
                { connection.CloseIfNot(); }
            }
            Console.WriteLine("--------------------------------------------------------");

            SimpleDbCommand command = new SimpleDbCommand()
            {
                CommandType = CommandType.Text,
                CommandText = "select * from `classicmodels`.`orderdetails` where `orderNumber` = @orderNumber"
            };
            command.AddParameter(new DbCommandParameter { ParameterName = "orderNumber", Value = orderNumber });

            using (IDbConnection connection = GetDbConnection())
            {
                try
                {
                    connection.OpenIfNot();
                    long result = connection.CountLong(command);
                    Console.WriteLine(result == 4 ? "4 kayıt bulundu." : $"Hatalı sonuç. {result} kayıt bulundu. ");
                }
                finally
                { connection.CloseIfNot(); }
            }
            Console.WriteLine("--------------------------------------------------------");
            Console.ReadKey();
        }
    }
}