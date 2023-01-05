using MySql.Data.MySqlClient;
using Simply.Data.Database;
using System.Data;

namespace Simply_Test_Db
{
    public class SimpleMySqlDatabase : SimpleDatabase
    {
        internal static IDbConnection GetDbConnection()
        {
            MySqlConnection connection = new MySqlConnection();
            connection.ConnectionString = "data source=127.0.0.1;initial catalog=classicmodels;user id=root;";//ConfigurationManager.AppSettings["connectionString"];
            return connection;
            // return new MySqlConnection { ConnectionString = "data source=127.0.0.1;initial catalog=classicmodels;user id=root;" };
        }

        public SimpleMySqlDatabase() : base(GetDbConnection())
        {
        }
    }
}