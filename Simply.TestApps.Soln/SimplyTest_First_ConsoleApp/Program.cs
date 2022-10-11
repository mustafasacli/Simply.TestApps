using Simply.Common.Objects;
using Simply.Data;
using Simply.Data.Interfaces;
using Simply.Data.Objects;
using Simply_Test_Db;
using SimplyTest_Entities;
using System;
using System.Data;
using System.Reflection;

namespace SimplyTest_First_ConsoleApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string productCode = "S18_2325";
            ISimpleDatabase database = new SimpleMySqlDatabase();

            Orderdetails orderDetail = database.First<Orderdetails>(
                "select * from `classicmodels`.`orderdetails` WHERE `productCode` = ?productCode?",
                new { productCode }, commandSetting: SimpleCommandSetting.Create().SetParameterNamePrefix('?'));
            writeEntity(orderDetail);
            Console.WriteLine("--------------------------------------------------------");

            Orderdetails orderDetail2 = database.First<Orderdetails>(
                "select * from `classicmodels`.`orderdetails` WHERE `productCode` = ?",
                new { productCode });
            writeEntity(orderDetail2);
            Console.WriteLine("--------------------------------------------------------");

            SimpleDbCommand command = new SimpleDbCommand();
            command.CommandText =
                "select * from `classicmodels`.`orderdetails` WHERE `productCode` = @productCode";
            command.AddParameter(new DbCommandParameter { Direction = ParameterDirection.Input, ParameterName = "productCode", Value = productCode });

            var orderDetail3 = database.First<Orderdetails>(command);
            writeEntity(orderDetail3);
            Console.WriteLine("--------------------------------------------------------");

            Orderdetails orderDetail4 = database.FirstOdbc<Orderdetails>(
                "select * from `classicmodels`.`orderdetails` WHERE `productCode` = ?",
                new[] { productCode });
            writeEntity(orderDetail4);
            Console.WriteLine("--------------------------------------------------------");
            command = new SimpleDbCommand();
            command.CommandText =
                "select * from `classicmodels`.`orderdetails` WHERE `productCode` = @productCode";
            command.AddParameter(new DbCommandParameter { Direction = ParameterDirection.Input, ParameterName = "productCode", Value = productCode });

            var orderDetailRowResult = database.FirstRow(command);
            writeDbRow(orderDetailRowResult);

            Console.WriteLine("--------------------------------------------------------");
            SimpleDbRow orderDetailRow = database.FirstRowOdbc(
                "select * from `classicmodels`.`orderdetails` WHERE `productCode` = ?",
                new[] { productCode });
            writeDbRow(orderDetailRow);
            Console.WriteLine("--------------------------------------------------------");

            Console.ReadKey();
        }

        private static void writeDbRow(SimpleDbRow row)
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

        private static void writeEntity<TEntity>(TEntity entity) where TEntity : class
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