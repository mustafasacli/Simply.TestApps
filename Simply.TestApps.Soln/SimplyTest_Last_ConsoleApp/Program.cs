using Simply.Common.Objects;
using Simply.Data;
using Simply.Data.Interfaces;
using Simply.Data.Objects;
using Simply_Test_Db;
using SimplyTest_Entities;
using System;
using System.Data;
using System.Reflection;

namespace SimplyTest_Last_ConsoleApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string productCode = "S18_2325";
            ISimpleDatabase database = new SimpleMySqlDatabase();
            Orderdetails orderDetail = database.Last<Orderdetails>("select * from `classicmodels`.`orderdetails` WHERE `productCode` = ?productCode?",
                       new { productCode }, commandSetting: SimpleCommandSetting.Create().SetParameterNamePrefix('?'));
            WriteEntity(orderDetail);
            Console.WriteLine("--------------------------------------------------------");

            Orderdetails orderDetail2 = database.Last<Orderdetails>(
                "select * from `classicmodels`.`orderdetails` WHERE `productCode` = ?",
                new { productCode });
            WriteEntity(orderDetail2);
            Console.WriteLine("--------------------------------------------------------");
            SimpleDbCommand command = new SimpleDbCommand
            {
                CommandText =
                "select * from `classicmodels`.`orderdetails` WHERE `productCode` = @productCode"
            };
            command.AddParameter(new DbCommandParameter { Direction = ParameterDirection.Input, ParameterName = "productCode", Value = productCode });

            Orderdetails orderDetail3 = database.Last<Orderdetails>(command);
            WriteEntity(orderDetail3);

            Console.WriteLine("--------------------------------------------------------");
            Orderdetails orderDetail4 = database.Last<Orderdetails>(
                "select * from `classicmodels`.`orderdetails` WHERE `productCode` = ?",
                new[] { productCode });
            WriteEntity(orderDetail4);
            Console.WriteLine("--------------------------------------------------------");

            SimpleDbCommand command2 = new SimpleDbCommand();
            command2.CommandText =
                "select * from `classicmodels`.`orderdetails` WHERE `productCode` = @productCode";
            command2.AddParameter(new DbCommandParameter { Direction = ParameterDirection.Input, ParameterName = "productCode", Value = productCode });
            SimpleDbRow orderDetailRow = database.LastRow(command2);
            WriteDbRow(orderDetailRow);
            Console.WriteLine("--------------------------------------------------------");

            SimpleDbRow orderDetailRow2 = database.LastRow(
                "select * from `classicmodels`.`orderdetails` WHERE `productCode` = @productCode",
                new { productCode });
            WriteDbRow(orderDetailRow2);
            Console.WriteLine("--------------------------------------------------------");

            SimpleDbRow orderDetailRow3 = database.LastRow(
                "select * from `classicmodels`.`orderdetails` WHERE `productCode` = #productCode#",
                new { productCode }, commandSetting: SimpleCommandSetting.Create().SetParameterNamePrefix('#'));
            WriteDbRow(orderDetailRow3);
            Console.WriteLine("--------------------------------------------------------");

            Console.ReadKey();
        }

        private static void WriteDbRow(SimpleDbRow row)
        {
            if (row != null)
            {
                foreach (SimpleDbCell cell in row.Cells)
                {
                    Console.WriteLine($"Name: {cell.CellName}, Type: {cell.CellType.Name}, Value:{cell.Value?.ToString() ?? "'NULL'"}");
                }
                Console.WriteLine("************************************");
            }
        }

        private static void WriteEntity<TEntity>(TEntity entity) where TEntity : class
        {
            if (entity == null) return;

            var properties = typeof(TEntity).GetProperties();
            foreach (PropertyInfo property in properties)
            {
                Console.WriteLine($"Property Name:#{property.Name}#, Type: #{property.PropertyType.Name}#, Value:#{property.GetValue(entity, null) ?? "'#NULL#'"}#");
            }
        }
    }
}