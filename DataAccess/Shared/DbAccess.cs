using System;
using System.Data.Common;
using System.Data.SqlClient;
using System.Reflection;

namespace DataAccess.Shared
{
    public class DbAccess
    {
        public static string conString = "Data Source=itstar.company;Initial Catalog=Financial_Management_System;User ID=user_fms;Password=user$fms";

        public static Func<DbConnection> ConnectionFactory = () => new SqlConnection(conString);

        public static string USER_ID;

        public static string SelectAll<T>()
        {
            return "SELECT * FROM " + typeof(T).Name;
        }

        public static string Select<T>()
        {
            return "SELECT * FROM " + typeof(T).Name + " WHERE " + GetPKColumns<T>();
        }

        public static string Insert<T>()
        {
            return "INSERT INTO " + typeof(T).Name + "(" + GetColumns<T>(Coltype.type1) + ") VALUES(" + GetColumns<T>(Coltype.type2) + ")";
        }

        public static string Update<T>()
        {
            return "UPDATE " + typeof(T).Name + " SET " + GetColumns<T>(Coltype.type3) + " WHERE " + GetPKColumns<T>();
        }

        public static string Delete<T>()
        {
            return "DELETE FROM " + typeof(T).Name + " WHERE " + GetPKColumns<T>();
        }

        #region Reflection Helper

        enum Coltype
        {
            type1, // col
            type2, // @col
            type3 // col=@col
        }

        private static string GetColumns<T>(Coltype type)
        {
            string result = "";

            foreach (var pInfo in typeof(T).GetProperties())
            {
                if (!IsValidColumn(pInfo)) continue;

                switch (type)
                {
                    case Coltype.type1:
                        result += pInfo.Name + ",";
                        break;
                    case Coltype.type2:
                        result += "@" + pInfo.Name + ",";
                        break;
                    case Coltype.type3:
                        result += pInfo.Name + "=@" + pInfo.Name + ",";
                        break;
                }
            }

            if (result.Length > 1) result = result.Remove(result.Length - 1);

            return result;
        }

        private static string GetPKColumns<T>()
        {
            string result = "";
            foreach (var pInfo in typeof(T).GetProperties())
            {
                if (!IsPKColumn(pInfo)) continue;

                result += pInfo.Name + "=@" + pInfo.Name;
            }

            return result;
        }

        private static bool IsPKColumn(PropertyInfo pInfo)
        {
            var atts = pInfo.GetCustomAttributes(true);

            if (atts.Length == 0) return false;

            return atts.GetValue(0).GetType().Name == "PrimaryKeyAttribute";
        }

        private static bool IsValidColumn(PropertyInfo pInfo)
        {
            return pInfo.PropertyType.IsPrimitive || pInfo.PropertyType.IsValueType || pInfo.PropertyType == typeof(string);
        }

        #endregion
    }
}
