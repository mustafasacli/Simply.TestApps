using Simply.Data;
using Simply.Data.Interfaces;
using Simply_Test_Db;
using SimplyTest_Entities;
using System;
using System.Reflection;
using static System.String;

namespace SimplyTest_ExecuteAsOdbc_ConsoleApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            int customerNumber = 103;
            ISimpleDatabase database = new SimpleMySqlDatabase();
            Customers customer;
            customer = GetCustomerById(database, customerNumber);
            Console.WriteLine("--------------------------------------------------------");

            if (customer != null)
            {
                Console.WriteLine("entity is not null.");

                decimal? newCreditLimit = 120000;
                string newCountry = "Turkey";

                string oldCountry = customer.Country;
                decimal? oldCreditLimit = customer.CreditLimit;

                int executionResult;

                executionResult = database.ExecuteOdbc(
                    "UPDATE `classicmodels`.`customers` SET country = ?, creditLimit = ? WHERE `customerNumber` = ?",
                    new object[] { newCountry, newCreditLimit, customerNumber });
                WriteEntity(customer);

                Console.WriteLine(Format("{0} rows affected.", executionResult));

                Customers customers2 = GetCustomerById(database, customerNumber);
                Console.WriteLine(customers2.Country == newCountry && customers2.CreditLimit == newCreditLimit ? "First update operation affected." : "First update operation not affected.");

                executionResult = database.ExecuteOdbc(
                    "UPDATE `classicmodels`.`customers` SET country = ?, creditLimit = ? WHERE `customerNumber` = ?",
                    new object[] { oldCountry, oldCreditLimit, customerNumber });
                WriteEntity(customer);

                Customers customers3 = GetCustomerById(database, customerNumber);
                Console.WriteLine(customers3.Country == customer.Country && customers3.CreditLimit == customer.CreditLimit ? "Second update operation affected." : "Second update operation not affected.");

                Console.WriteLine(Format("{0} rows affected.", executionResult));
            }
            else { Console.WriteLine("entity is null."); }

            Console.ReadKey();
        }

        private static Customers GetCustomerById(ISimpleDatabase database, int customerNumber)
        {
            Customers customer = database.SingleOdbc<Customers>(
                        "SELECT * FROM `classicmodels`.`customers` WHERE `customerNumber` = ?",
                        new[] { (object)customerNumber });
            WriteEntity(customer);

            return customer;
        }

        private static void WriteEntity<TEntity>(TEntity entity) where TEntity : class
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