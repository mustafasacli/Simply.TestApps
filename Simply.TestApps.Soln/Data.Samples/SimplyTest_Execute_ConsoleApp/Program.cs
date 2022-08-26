using MySql.Data.MySqlClient;
using Simply.Data;
using SimplyTest_Entities;
using System;
using System.Data;
using System.Reflection;
using static System.String;

namespace SimplyTest_Execute_ConsoleApp
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
            Customers customer;
            customer = GetCustomerById(customerNumber);
            Console.WriteLine("--------------------------------------------------------");

            if (customer != null)
            {
                Console.WriteLine("entity is not null.");

                decimal? newCreditLimit = 120000;
                string newCountry = "Turkey";

                string oldCountry = customer.Country;
                decimal? oldCreditLimit = customer.CreditLimit;

                int executionResult;

                using (IDbConnection connection = GetDbConnection())
                {
                    try
                    {
                        executionResult = connection.OpenAnd()
                            .Execute(
                            "UPDATE `classicmodels`.`customers` SET country = @newCountry, creditLimit = @newCreditLimit WHERE `customerNumber` = @customerNumber",
                            new { newCountry, newCreditLimit, customerNumber });
                        writeEntity(customer);
                    }
                    finally
                    { connection.CloseIfNot(); }
                }

                Console.WriteLine(Format("{0} rows affected.", executionResult));

                Customers customers2 = GetCustomerById(customerNumber);
                Console.WriteLine(customers2.Country == newCountry && customers2.CreditLimit == newCreditLimit ?
                    "First update operation affected." : "First update operation not affected.");

                using (IDbConnection connection = GetDbConnection())
                {
                    try
                    {
                        executionResult = connection.OpenAnd()
                            .Execute(
                            "UPDATE `classicmodels`.`customers` SET country = @oldCountry, creditLimit = @oldCreditLimit WHERE `customerNumber` = @customerNumber",
                            new { oldCountry, oldCreditLimit, customerNumber });
                        writeEntity(customer);
                    }
                    finally
                    { connection.CloseIfNot(); }
                }

                Customers customers3 = GetCustomerById(customerNumber);
                Console.WriteLine(customers3.Country == customer.Country && customers3.CreditLimit == customer.CreditLimit ?
                    "Second update operation affected." : "Second update operation not affected.");

                Console.WriteLine(Format("{0} rows affected.", executionResult));
            }
            else { Console.WriteLine("entity is null."); }

            Console.ReadKey();
        }

        private static Customers GetCustomerById(int customerNumber)
        {
            Customers customer;
            using (IDbConnection connection = GetDbConnection())
            {
                try
                {
                    customer = connection.OpenAnd()
                        .QuerySingle<Customers>(
                        "SELECT * FROM `classicmodels`.`customers` WHERE `customerNumber` = @customerNumber",
                        new { customerNumber });
                    writeEntity(customer);
                }
                finally
                { connection.CloseIfNot(); }
            }

            return customer;
        }

        private static void writeEntity<TEntity>(TEntity entity) where TEntity : class
        {
            if (entity == null) return;

            var properties = typeof(TEntity).GetProperties();
            foreach (PropertyInfo property in properties)
            {
                Console.WriteLine(
                    $"Property Name:#{property.Name}#, Type: #{property.PropertyType.Name}#, Value:#{property.GetValue(entity, null) ?? "'#NULL#'"}#");
            }
        }
    }
}