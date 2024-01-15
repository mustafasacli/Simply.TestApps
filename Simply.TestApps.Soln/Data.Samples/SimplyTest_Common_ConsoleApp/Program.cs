using Simply.Common;
using SimplyTest_Entities;
using System;
using System.Reflection;

namespace SimplyTest_Common_ConsoleApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Customers customer = new Customers();
            customer.With(q => q.Phone, "4568987546")
                .With(q => q.SalesRepEmployeeNumber, "12".ToIntNullable())
                .With(q => q.CustomerNumber, 150);

            var newCustomer = customer.DeepClone();
            writeEntity(customer);
            Console.WriteLine("-------------------------------------");
            newCustomer.With(q => q.State, "Wisconsin");
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