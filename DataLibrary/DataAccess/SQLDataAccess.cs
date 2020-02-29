using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper; //added 
using System.Configuration; //added
using System.Data; //added
using System.Data.SqlClient; // added

namespace DataLibrary.DataAccess
{
    public static class SQLDataAccess
    {
       public static string GetConnectionString(string connectionName = "MVCSQLDB")
        {
            return ConfigurationManager.ConnectionStrings[connectionName].ConnectionString;
        }

        public static List <T> LoadData<T>(String sql)
        {
            using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
            {
                return cnn.Query<T>(sql).ToList();
            }
        }

        public static int SaveData<T>(string sql, T data)
        {
            using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
            {
                return cnn.Execute(sql, data);
            }
        }
    }
}
