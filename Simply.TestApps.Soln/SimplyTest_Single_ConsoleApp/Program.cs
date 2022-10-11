using Simply.Common.Objects;
using Simply.Data;
using Simply.Data.Interfaces;
using Simply.Data.Objects;
using Simply_Test_Db;
using SimplyTest_Entities;
using System;
using System.Data;
using System.Reflection;

namespace SimplyTest_Single_ConsoleApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            int customerNumber = 103;

            try
            {
                ISimpleDatabase database = new SimpleMySqlDatabase();
                Customers customer1 = database
                    .Single<Customers>("SELECT * FROM `classicmodels`.`customers` WHERE `customerNumber` = ?customerNumber?",
                    new { customerNumber }, commandSetting: SimpleCommandSetting.Create().SetParameterNamePrefix('?'));
                writeEntity(customer1);
                Console.WriteLine("--------------------------------------------------------");

                Customers customer2 = database
                    .Single<Customers>(
                    "SELECT * FROM `classicmodels`.`customers` WHERE `customerNumber` = ?",
                    new object[] { customerNumber });
                writeEntity(customer2);
                Console.WriteLine("--------------------------------------------------------");

                SimpleDbCommand command = new SimpleDbCommand();
                command.CommandText =
                    "SELECT * FROM `classicmodels`.`customers` WHERE `customerNumber` = @customerNumber";
                command.AddParameter(new DbCommandParameter { Direction = ParameterDirection.Input, ParameterName = "customerNumber", Value = customerNumber });
                Customers customer3 = database
                            .Single<Customers>(command);
                writeEntity(customer3);
                Console.WriteLine("--------------------------------------------------------");

                SimpleDbRow customerRow = database
                    .SingleRow(
                    "SELECT * FROM `classicmodels`.`customers` WHERE `customerNumber` = @customerNumber",
                    new { customerNumber });
                writeDbRow(customerRow);
                Console.WriteLine("--------------------------------------------------------");

                SimpleDbRow customerRow2 = database
                    .SingleRow(
                    "SELECT * FROM `classicmodels`.`customers` WHERE `customerNumber` = #customerNumber#",
                    new { customerNumber }, commandSetting: SimpleCommandSetting.Create().SetParameterNamePrefix('#'));
                writeDbRow(customerRow2);
                Console.WriteLine("--------------------------------------------------------");

                string productCode = "S18_2325";
                Orderdetails orderDetail = database
                        .Single<Orderdetails>("select * from `classicmodels`.`orderdetails` WHERE `productCode` = ?productCode?",
                            new { productCode }, commandSetting: SimpleCommandSetting.Create().SetParameterNamePrefix('?'));
                writeEntity(orderDetail);
            }
            catch (Exception ex)
            { Console.WriteLine(ex.ToString()); }
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