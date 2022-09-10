using MySql.Data.MySqlClient;
using Simply.Data.Database;
using Simply.Data.Objects;
using System.Data;

namespace Simply_Test_Db
{
    public class SimpleMySqlDatabase : SimpleDatabase
    {
        internal static IDbConnection GetDbConnection()
        {
            return new MySqlConnection { ConnectionString = "data source=127.0.0.1;initial catalog=classicmodels;user id=root;" };
        }

        public SimpleMySqlDatabase() : base(GetDbConnection(),
            commandSetting: SimpleCommandSetting.Create(parameterNamePrefix: '?'))
        {
        }
    }
}