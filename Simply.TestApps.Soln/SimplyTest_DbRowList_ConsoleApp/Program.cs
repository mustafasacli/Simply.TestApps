using MySql.Data.MySqlClient;
using Simply.Common;
using Simply.Common.Objects;
using Simply.Data;
using Simply.Data.Objects;
using System;
using System.Collections.Generic;
using System.Data;

namespace SimplyTest_DbRowList_ConsoleApp
{
    internal class Program
    {
        internal static IDbConnection GetDbConnection()
        {
            return new MySqlConnection { ConnectionString = "data source=127.0.0.1;initial catalog=classicmodels;user id=root;" };
        }
        // SELECT * FROM orderdetails WHERE productCode='S18_2325';
        // select * from `classicmodels`.`orderdetails` WHERE `productCode` = @productCode;
        // select * from `classicmodels`.`orderdetails` WHERE `productCode` = ?;
        static void Main(string[] args)
        {
            string productCode = "S18_2325";

            using (IDbConnection connection = GetDbConnection())
            {
                try
                {
                    connection.OpenIfNot();
                    var rowList = connection.QueryDbRowList("select * from `classicmodels`.`orderdetails` WHERE `productCode` = ?productCode?",
                        new { productCode },
                        commandSetting: SimpleCommandSetting.Create().SetParameterNamePrefix('?'), pageInfo: null);
                    Console.WriteLine($"{rowList.Count} rows returned.");
                    writeDbRows(rowList);
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
                    var rowList = connection.QueryDbRowList("select * from `classicmodels`.`orderdetails` WHERE `productCode` = @productCode",
                        new { productCode });
                    Console.WriteLine($"{rowList.Count} rows returned.");
                    writeDbRows(rowList);
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
                    var rowList = connection.QueryDbRowList("select * from `classicmodels`.`orderdetails` WHERE `productCode` = ?productCode?",
                        new { productCode }, commandSetting: SimpleCommandSetting.Create().SetParameterNamePrefix('?')
                        , pageInfo: PageInfo.GetPageWithPageNumber(2, 10));
                    Console.WriteLine($"{rowList.Count} rows returned.");
                    writeDbRows(rowList);
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
                    var rowList = connection.QueryDbRowList("select * from `classicmodels`.`orderdetails` WHERE `productCode` = @productCode",
                        new { productCode }, pageInfo: PageInfo.GetPageWithPageNumber(3, 10));
                    Console.WriteLine($"{rowList.Count} rows returned.");
                    writeDbRows(rowList);
                }
                finally
                { connection.CloseIfNot(); }
            }
            Console.WriteLine("--------------------------------------------------------");

            Console.ReadKey();
        }

        static void writeDbRows(List<SimpleDbRow> rows)
        {
            if (!ArrayHelper.IsNullOrEmpty(rows))
            {
                foreach (SimpleDbRow row in rows)
                {
                    foreach (SimpleDbCell cell in row.Cells)
                    {
                        Console.WriteLine($"Name: {cell.CellName}, Type: {cell.CellType.Name}, Value:{cell.Value?.ToString() ?? "'NULL'"}");
                    }
                    Console.WriteLine("************************************");
                }
            }
        }
    }
}
