using Simply.Data;
using Simply.Data.Interfaces;
using Simply.Data.Objects;
using Simply_Test_Db;
using SimplyTest_Entities;
using System;

namespace SimplyTest_List_ConsoleApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string productCode = "S18_2325";

            ISimpleDatabase database = new SimpleMySqlDatabase();
            var rowList1 = database.List<Orderdetails>("select * from `classicmodels`.`orderdetails` WHERE `productCode` = ?productCode?",
                new { productCode }, commandSetting: SimpleCommandSetting.Create().SetParameterNamePrefix('?'), pageInfo: null);
            Console.WriteLine($"{rowList1.Count} rows returned.");
            //writeDbRows(rowList1);
            Console.WriteLine("--------------------------------------------------------");

            var rowList2 = database.List<Orderdetails>("select * from `classicmodels`.`orderdetails` WHERE `productCode` = @productCode",
                new { productCode });
            Console.WriteLine($"{rowList2.Count} rows returned.");
            //writeDbRows(rowList2);
            Console.WriteLine("--------------------------------------------------------");

            var rowList3 = database.List<Orderdetails>("select * from `classicmodels`.`orderdetails` WHERE `productCode` = ?productCode?",
                new { productCode }, commandSetting: SimpleCommandSetting.Create().SetParameterNamePrefix('?'), pageInfo: PageInfo.GetPageWithPageNumber(2, 10));
            Console.WriteLine($"{rowList3.Count} rows returned.");
            //writeDbRows(rowList3);
            Console.WriteLine("--------------------------------------------------------");

            var rowList4 = database.List<Orderdetails>("select * from `classicmodels`.`orderdetails` WHERE `productCode` = @productCode",
                new { productCode }, pageInfo: PageInfo.GetPageWithPageNumber(3, 10));
            Console.WriteLine($"{rowList4.Count} rows returned.");
            //writeDbRows(rowList4);
            Console.WriteLine("--------------------------------------------------------");

            Console.ReadKey();
        }
    }
}