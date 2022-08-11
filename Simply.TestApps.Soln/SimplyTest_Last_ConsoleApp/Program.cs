using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Simply.Common.Objects;
using Simply.Data;
using Simply.Data.Objects;
using SimplyTest_Entities;
using System;
using System.Data;
using System.Reflection;

namespace SimplyTest_Last_ConsoleApp
{
    internal class Program
    {
        internal static IDbConnection GetDbConnection()
        {
            return new MySqlConnection { ConnectionString = "data source=127.0.0.1;initial catalog=classicmodels;user id=root;" };
        }

        private static void Main(string[] args)
        {
            string productCode = "S18_2325";
            using (IDbConnection connection = GetDbConnection())
            {
                try
                {
                    connection.OpenIfNot();
                    var orderDetail = connection.QueryLast<Orderdetails>("select * from `classicmodels`.`orderdetails` WHERE `productCode` = ?productCode?",
                        new { productCode }, parameterNamePrefix: '?');
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
                    connection.OpenIfNot();
                    var orderDetail = connection.QueryLast<Orderdetails>(
                        "select * from `classicmodels`.`orderdetails` WHERE `productCode` = ?",
                        new { productCode });
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
                    SimpleDbCommand command = new SimpleDbCommand();
                    command.CommandText =
                        "select * from `classicmodels`.`orderdetails` WHERE `productCode` = @productCode";
                    command.AddParameter(new DbCommandParameter { Direction = ParameterDirection.Input, ParameterName = "productCode", Value = productCode });
                    connection.OpenIfNot();
                    var orderDetail = connection.QueryLast<Orderdetails>(command);
                    writeEntity(orderDetail.Result);
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
                    var orderDetail = connection.GetLast<Orderdetails>(
                        "select * from `classicmodels`.`orderdetails` WHERE `productCode` = ?",
                        new[] { productCode });
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
                    SimpleDbCommand command = new SimpleDbCommand();
                    command.CommandText =
                        "select * from `classicmodels`.`orderdetails` WHERE `productCode` = @productCode";
                    command.AddParameter(new DbCommandParameter { Direction = ParameterDirection.Input, ParameterName = "productCode", Value = productCode });
                    connection.OpenIfNot();
                    var orderDetailRowResult = connection.QueryLastAsDbRow(command);
                    writeDbRow(orderDetailRowResult.Result);
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
                    var orderDetailRow = connection.QueryLastDbRow(
                        "select * from `classicmodels`.`orderdetails` WHERE `productCode` = @productCode",
                        new { productCode });
                    writeDbRow(orderDetailRow);
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
                    var orderDetailRow = connection.QueryLastDbRow(
                        "select * from `classicmodels`.`orderdetails` WHERE `productCode` = #productCode#",
                        new { productCode }, parameterNamePrefix: '#');
                    writeDbRow(orderDetailRow);
                }
                finally
                { connection.CloseIfNot(); }
            }
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
