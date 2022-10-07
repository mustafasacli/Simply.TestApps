using Simply.Common;
using Simply.Data;
using Simply.Data.Objects;
using KisayolYoneticisi.Source.BO;
using KisayolYoneticisi.Source.QO;
using KisayolYoneticisi.Source.Util;
using KisayolYoneticisi.Source.Variables;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using Simply.Data.Interfaces;
using System.Collections;

namespace KisayolYoneticisi.Source.OpManager
{
    internal class SQLiteManager
    {
        #region [ Execute method ]

        internal static int Execute(string query, object parameterObject)
        {
            int retInt = -1;

            using (ISimpleDatabase database = new SQLiteDatabase())
            {
                retInt = database.Execute(query, parameterObject);
            }

            return retInt;
        }

        #endregion [ Execute method ]


        #region [ Add method]

        public static int Add(Kisayol kisayol)
        {
            int retInt = Execute(Crud.InsertQuery(), new { kisayol.KisayolAdi, kisayol.Yol, kisayol.Tarih });
            return retInt;
        }

        #endregion [ Add method]

        #region [ Delete method ]

        public static int Delete(Kisayol kisayol)
        {
            int retInt = Execute(Crud.DeleteQuery(), new { kisayol.Id });
            return retInt;
        }

        #endregion [ Delete method ]

        #region [ Update method ]

        public static int Update(Kisayol kisayol)
        {
            int retInt = Execute(Crud.UpdateQuery(), new { kisayol.KisayolAdi, kisayol.Yol, kisayol.Tarih, kisayol.Id });
            return retInt;
        }

        #endregion [ Update method ]

        #region [ GetTable method ]

        public static DataTable GetTable()
        {
            DataTable table = null;

            using (ISimpleDatabase database = new SQLiteDatabase())
            {
                table = database.GetDataSet(Crud.GetTable(), null).Tables[0];
            }

            return table;
        }

        #endregion [ GetTable method ]

        #region [ AllList method ]

        public static List<Kisayol> AllList()
        {
            return DataUtility.ToList(GetTable());
        }

        #endregion [ AllList method ]

        public static int GetIdentity()
        {
            int retInt = -1;

            using (ISimpleDatabase database = new SQLiteDatabase())
            {
                retInt = database.ExecuteScalarAs<int>(Crud.GetIdentity(), null);
            }

            return retInt;
        }
    }
}