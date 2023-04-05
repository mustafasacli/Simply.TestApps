using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Simply.Common;
using SimplyTest_Entities;

namespace SimplyTest_Common_ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Customers customer = new Customers();
            customer.With(q => q.Phone, "4568987546")
                .With(q => q.SalesRepEmployeeNumber, "12".ToIntNullable())
                .With(q => q.CustomerNumber, 150);

            var newCustomer = customer.DeepClone();
            customer.With(q => q.State, "Wisconsin");
            writeEntity(customer);
            Console.WriteLine("-------------------------------------");
            writeEntity(newCustomer);
            Console.ReadKey();
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
