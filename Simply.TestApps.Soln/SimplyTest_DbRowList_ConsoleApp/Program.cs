using Simply.Common;
using Simply.Common.Objects;
using Simply.Data;
using Simply.Data.Interfaces;
using Simply.Data.Objects;
using Simply_Test_Db;
using System;
using System.Collections.Generic;

namespace SimplyTest_DbRowList_ConsoleApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string productCode = "S18_2325";
            ICommandSetting commandSetting = SimpleCommandSetting.Create(parameterNamePrefix: '?');
            List<SimpleDbRow> rowList;
            ISimpleDatabase database = new SimpleMySqlDatabase();

            string sql = "select * from `classicmodels`.`orderdetails` WHERE `productCode` = ?productCode?";
            rowList = database.ListRow(sql, new { productCode }, commandSetting, pageInfo: null);
            Console.WriteLine($"{rowList.Count} rows returned.");
            writeDbRows(rowList);
            Console.WriteLine("--------------------------------------------------------");

            sql = "select * from `classicmodels`.`orderdetails` WHERE `productCode` = @productCode";
            rowList = database.ListRow(sql, new { productCode }, pageInfo: null);
            Console.WriteLine($"{rowList.Count} rows returned.");
            writeDbRows(rowList);
            Console.WriteLine("--------------------------------------------------------");

            sql = "select * from `classicmodels`.`orderdetails` WHERE `productCode` = ?productCode?";
            rowList = database.ListRow(sql, new { productCode },
                commandSetting: SimpleCommandSetting.Create(parameterNamePrefix: '?'),
                pageInfo: PageInfo.GetPageWithPageNumber(2, 10));
            Console.WriteLine($"{rowList.Count} rows returned.");
            writeDbRows(rowList);
            Console.WriteLine("--------------------------------------------------------");

            sql = "select * from `classicmodels`.`orderdetails` WHERE `productCode` =  @productCode";
            rowList = database.ListRow(sql, new { productCode },
                commandSetting: SimpleCommandSetting.Create(parameterNamePrefix: '?'),
                pageInfo: PageInfo.GetPageWithPageNumber(3, 10));
            Console.WriteLine($"{rowList.Count} rows returned.");
            writeDbRows(rowList);
            Console.WriteLine("--------------------------------------------------------");

            Console.ReadKey();
        }

        private static void writeDbRows(List<SimpleDbRow> rows)
        {
            if (ArrayHelper.IsNullOrEmpty(rows))
                return;

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