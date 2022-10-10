using Simply.Data;
using Simply.Data.ConnectionExtensions;
using Simply.Data.Interfaces;
using Simply.Data.Objects;
using Simply_Test_Db;
using System;
using System.Data;

namespace SimplyTest_Count_ConsoleApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            int orderNumber = 10100;
            ISimpleDatabase database = new SimpleMySqlDatabase();
            string sql = "select * from `classicmodels`.`orderdetails` where `orderNumber` = @orderNumber";
            long result = database.CountLong(sql, new { orderNumber });
            Console.WriteLine(result == 4 ? "4 kayıt bulundu." : $"Hatalı sonuç. {result} kayıt bulundu. ");
            Console.WriteLine("--------------------------------------------------------");

            sql = "select * from `classicmodels`.`orderdetails` where `orderNumber` = ?orderNumber?";
            result = database.CountLong(sql, new { orderNumber },
                SimpleCommandSetting.New().SetParameterNamePrefix(parameterNamePrefix: '?'));
            Console.WriteLine(result == 4 ? "4 kayıt bulundu." : $"Hatalı sonuç. {result} kayıt bulundu. ");
            Console.WriteLine("--------------------------------------------------------");

            sql = "select * from `classicmodels`.`orderdetails` where `orderNumber` = ?";
            result = database.CountLongOdbc(sql, new[] { (object)orderNumber });
            Console.WriteLine(result == 4 ? "4 kayıt bulundu." : $"Hatalı sonuç. {result} kayıt bulundu. ");
            Console.WriteLine("--------------------------------------------------------");

            SimpleDbCommand command = new SimpleDbCommand()
            {
                CommandType = CommandType.Text,
                CommandText = "select * from `classicmodels`.`orderdetails` where `orderNumber` = @orderNumber"
            };
            command.AddParameter(new DbCommandParameter { ParameterName = "orderNumber", Value = orderNumber });
            result = database.CountLong(command);
            Console.WriteLine(result == 4 ? "4 kayıt bulundu." : $"Hatalı sonuç. {result} kayıt bulundu. ");
            Console.WriteLine("--------------------------------------------------------");

            Console.ReadKey();
        }
    }
}