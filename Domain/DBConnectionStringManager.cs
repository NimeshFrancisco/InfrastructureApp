using System;
using System.Data.SqlClient;
using System.Configuration;

namespace Domain
{
    public static class DBConnectionStringManager
    {
       
        public static SqlConnection GetConnection(string connstringSettingKey)
        {
            SqlConnection connection = null;
            if (ConfigurationManager.ConnectionStrings[connstringSettingKey] != null)
            {
                string constring = ConfigurationManager.ConnectionStrings[connstringSettingKey].ConnectionString;
                connection = new SqlConnection(constring);
            }
            return connection;
        }
    }
}
