using MySql.Data.MySqlClient;
using Simply.Common.Objects;
using Simply.Data;
using Simply.Data.Objects;
using SimplyTest_Entities;
using System;
using System.Data;
using System.Reflection;

namespace SimplyTest_Single_ConsoleApp
{
    internal class Program
    {
        internal static IDbConnection GetDbConnection()
        {
            return new MySqlConnection { ConnectionString = "data source=127.0.0.1;initial catalog=classicmodels;user id=root;" };
        }

        private static void Main(string[] args)
        {
            int customerNumber = 103;
            using (IDbConnection connection = GetDbConnection())
            {
                try
                {
                    var orderDetail = connection.OpenAnd()
                        .QuerySingle<Customers>("SELECT * FROM `classicmodels`.`customers` WHERE `customerNumber` = ?customerNumber?",
                        new { customerNumber }, parameterNamePrefix: '?');
                    writeEntity(orderDetail);
                }
                finally
                { connection.CloseIfNot(); }
            }
            Console.WriteLine("--------------------------------------------------------");
            using (IDbConnection connection = GetDbConnection())
            {
                try
                {
                    var customer = connection.OpenAnd()
                        .GetSingle<Customers>(
                        "SELECT * FROM `classicmodels`.`customers` WHERE `customerNumber` = ?",
                        new object[] { customerNumber });
                    writeEntity(customer);
                }
                finally
                { connection.CloseIfNot(); }
            }
            Console.WriteLine("--------------------------------------------------------");

            using (IDbConnection connection = GetDbConnection())
            {
                try
                {
                    SimpleDbCommand command = new SimpleDbCommand();
                    command.CommandText =
                        "SELECT * FROM `classicmodels`.`customers` WHERE `customerNumber` = @customerNumber";
                    command.AddParameter(new DbCommandParameter { Direction = ParameterDirection.Input, ParameterName = "customerNumber", Value = customerNumber });
                    var customer = connection.OpenAnd()
                        .QuerySingle<Customers>(command);
                    writeEntity(customer.Result);
                }
                finally
                { connection.CloseIfNot(); }
            }
            Console.WriteLine("--------------------------------------------------------");

            using (IDbConnection connection = GetDbConnection())
            {
                try
                {
                    var customerRow = connection.OpenAnd()
                        .QuerySingleAsDbRow(
                        "SELECT * FROM `classicmodels`.`customers` WHERE `customerNumber` = @customerNumber",
                        new { customerNumber });
                    writeDbRow(customerRow);
                }
                finally
                { connection.CloseIfNot(); }
            }
            Console.WriteLine("--------------------------------------------------------");
            using (IDbConnection connection = GetDbConnection())
            {
                try
                {
                    var customerRow = connection.OpenAnd()
                        .QuerySingleAsDbRow(
                        "SELECT * FROM `classicmodels`.`customers` WHERE `customerNumber` = #customerNumber#",
                        new { customerNumber }, parameterNamePrefix: '#');
                    writeDbRow(customerRow);
                }
                finally
                { connection.CloseIfNot(); }
            }
            Console.WriteLine("--------------------------------------------------------");
            try
            {
                string productCode = "S18_2325";
                using (IDbConnection connection = GetDbConnection())
                {
                    try
                    {
                        var orderDetail = connection.OpenAnd()
                            .QuerySingle<Orderdetails>("select * from `classicmodels`.`orderdetails` WHERE `productCode` = ?productCode?",
                            new { productCode }, parameterNamePrefix: '?');
                        writeEntity(orderDetail);
                    }
                    finally
                    { connection.CloseIfNot(); }
                }
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