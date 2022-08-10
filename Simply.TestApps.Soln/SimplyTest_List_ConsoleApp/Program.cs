using MySql.Data.MySqlClient;
using Simply.Data;
using Simply.Data.Objects;
using SimplyTest_Entities;
using System;
using System.Data;

namespace SimplyTest_List_ConsoleApp
{
    internal class Program
    {
        internal static IDbConnection GetDbConnection()
        {
            return new MySqlConnection { ConnectionString = "data source=127.0.0.1;initial catalog=classicmodels;user id=root;" };
        }

        static void Main(string[] args)
        {
            string productCode = "S18_2325";

            using (IDbConnection connection = GetDbConnection())
            {
                try
                {
                    connection.OpenIfNot();
                    var rowList = connection.QueryList<Orderdetails>("select * from `classicmodels`.`orderdetails` WHERE `productCode` = ?productCode?",
                        new { productCode }, parameterNamePrefix: '?', pageInfo: null);
                    Console.WriteLine($"{rowList.Count} rows returned.");
                    //writeDbRows(rowList);
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
                    var rowList = connection.QueryList<Orderdetails>("select * from `classicmodels`.`orderdetails` WHERE `productCode` = @productCode",
                        new { productCode });
                    Console.WriteLine($"{rowList.Count} rows returned.");
                    //writeDbRows(rowList);
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
                    var rowList = connection.QueryList<Orderdetails>("select * from `classicmodels`.`orderdetails` WHERE `productCode` = ?productCode?",
                        new { productCode }, parameterNamePrefix: '?', pageInfo: PageInfo.GetPageWithPageNumber(2, 10));
                    Console.WriteLine($"{rowList.Count} rows returned.");
                    //writeDbRows(rowList);
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
                    var rowList = connection.QueryList<Orderdetails>("select * from `classicmodels`.`orderdetails` WHERE `productCode` = @productCode",
                        new { productCode }, pageInfo: PageInfo.GetPageWithPageNumber(3, 10));
                    Console.WriteLine($"{rowList.Count} rows returned.");
                    //writeDbRows(rowList);
                }
                finally
                { connection.CloseIfNot(); }
            }
            Console.WriteLine("--------------------------------------------------------");

            Console.ReadKey();
        }
    }
}
