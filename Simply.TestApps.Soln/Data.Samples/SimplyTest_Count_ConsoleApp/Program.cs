using MySql.Data.MySqlClient;
using Simply.Data;
using Simply.Data.ConnectionExtensions;
using Simply.Data.Objects;
using System;
using System.Data;
using System.Linq;

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
                connection.OpenIfNot();
                int result = connection.Count("select * from orderdetails where orderNumber = @orderNumber", new { orderNumber });
                Console.WriteLine(result == 4 ? "4 kayıt bulundu." : $"Hatalı sonuç. {result} kayıt bulundu. ");
            }
            using (IDbConnection connection = GetDbConnection())
            {
                connection.OpenIfNot();
                long result = connection.CountLong("select * from `orderdetails` where `orderNumber` = @orderNumber", new { orderNumber });
                Console.WriteLine(result == 4 ? "4 kayıt bulundu." : $"Hatalı sonuç. {result} kayıt bulundu. ");
            }
            Console.WriteLine("--------------------------------------------------------");
            using (IDbConnection connection = GetDbConnection())
            {
                connection.OpenIfNot();
                int result = connection.Count("select * from orderdetails where orderNumber = ?", new object[] { orderNumber });
                Console.WriteLine(result == 4 ? "4 kayıt bulundu." : $"Hatalı sonuç. {result} kayıt bulundu. ");
            }
            using (IDbConnection connection = GetDbConnection())
            {
                connection.OpenIfNot();
                long result = connection.CountLong("select * from orderdetails where orderNumber = ?", new object[] { orderNumber });
                Console.WriteLine(result == 4 ? "4 kayıt bulundu." : $"Hatalı sonuç. {result} kayıt bulundu. ");
            }
            Console.WriteLine("--------------------------------------------------------");
            using (IDbConnection connection = GetDbConnection())
            {
                connection.OpenIfNot();
                int result = connection.Count("select * from orderdetails where orderNumber = ?", new object[] { orderNumber });
                Console.WriteLine(result == 4 ? "4 kayıt bulundu." : $"Hatalı sonuç. {result} kayıt bulundu. ");
            }
            using (IDbConnection connection = GetDbConnection())
            {
                connection.OpenIfNot();
                long result = connection.CountLong("select * from orderdetails where orderNumber = ?", new object[] { orderNumber });
                Console.WriteLine(result == 4 ? "4 kayıt bulundu." : $"Hatalı sonuç. {result} kayıt bulundu. ");
            }
            Console.WriteLine("--------------------------------------------------------");

            SimpleDbCommand command = new SimpleDbCommand()
            {
                CommandType = CommandType.Text,
                CommandText = "select * from orderdetails where orderNumber = @orderNumber"
            };
            command.AddParameter(new DbCommandParameter { ParameterName = "orderNumber", Value = orderNumber });
            using (IDbConnection connection = GetDbConnection())
            {
                connection.OpenIfNot();
                int result = connection.Count(command);
                Console.WriteLine(result == 4 ? "4 kayıt bulundu." : $"Hatalı sonuç. {result} kayıt bulundu. ");
            }
            using (IDbConnection connection = GetDbConnection())
            {
                connection.OpenIfNot();
                long result = connection.CountLong(command);
                Console.WriteLine(result == 4 ? "4 kayıt bulundu." : $"Hatalı sonuç. {result} kayıt bulundu. ");
            }
            Console.WriteLine("--------------------------------------------------------");
            Console.ReadKey();
        }
    }
}