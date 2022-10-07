using KisayolYoneticisi.Source.Variables;
using Simply.Data.Database;
using System.Data.SQLite;

namespace KisayolYoneticisi.Source.OpManager
{
    internal class SQLiteDatabase : SimpleDatabase
    {
        public SQLiteDatabase()
            : base(new SQLiteConnection(AppVariables.ConnectionString))
        {
        }
    }
}