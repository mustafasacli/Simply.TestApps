using Simply.Common;
using Simply.Common.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simply.Common.ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            IDictionary<string, object> vals = new Dictionary<string, object>();
            vals["amount"] = 3.45;
            vals["year"] = 2023;
            vals["age"] = 36;
            vals["birthDate"] = new DateTime(1991, 4, 6);
            vals["discount"] = 4.6f;
            vals["text"] = "Marry has a little lamb.";
            vals["longAmount"] = long.MaxValue;
            vals["intAmount"] = int.MaxValue;
            vals["decVal"] = decimal.MaxValue;
            vals["nullVal"] = null;
            vals["dbnullVal"] = DBNull.Value;
            vals["boolValue"] = true;

            var setting = SimpleFormatSetting.New().SetMainXmlNodeName("row").SetTab(false).SetNewLine(false).SetDatetimeFormat("dd-MM-yyyy");

            string xml = vals.ToXmlString(setting);
            Console.WriteLine("Xml;");
            Console.WriteLine(xml);
            string json = vals.ToJsonString(setting.SetDatetimeFormat("dd/MM/yyyy"));
            Console.WriteLine("JSON;");
            Console.WriteLine(json);
            Console.ReadKey();

            SimpleDbRow row = SimpleDbRow.NewRow()
                .AddCellAndReturn("amount", typeof(double), 3.45)
                .AddCellAndReturn("year", typeof(int), 2023)
                .AddCellAndReturn("age", typeof(int), 36)
                .AddCellAndReturn("birthDate", typeof(DateTime), new DateTime(1991, 4, 6))
                .AddCellAndReturn("discount", typeof(float), 4.6f)
                .AddCellAndReturn("text", typeof(string), "Marry has a little lamb.")
                .AddCellAndReturn("longAmount", typeof(long), long.MaxValue)
                .AddCellAndReturn("intAmount", typeof(int), int.MaxValue)
                .AddCellAndReturn("decVal", typeof(decimal), decimal.MaxValue)
                .AddCellAndReturn("nullVal", typeof(object), null)
                .AddCellAndReturn("dbnullVal", typeof(object), DBNull.Value)
                .AddCellAndReturn("boolValue", typeof(bool), false);

            Console.WriteLine("----------------------------------------------");
            xml = row.ToXmlString(setting.SetDatetimeFormat("dd-MM-yyyy"));
            Console.WriteLine("Row Xml;");
            Console.WriteLine(xml);
            json = row.ToJsonString(setting.SetDatetimeFormat("dd/MM/yyyy"));
            Console.WriteLine("Row JSON;");
            Console.WriteLine(json);
            Console.ReadKey();
        }
    }
}
