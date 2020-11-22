using System;
using System.Data.SqlClient;

namespace KWSAdmin.Persistence
{
    public class DbConnection
    {
        string connectionString = "Persist Security Info=False;" +
            "User ID=KwsDatabase;" +
            "Password=KwsDatabase123;" +
            "Initial Catalog=KwsAdmin;" +
            "Server=84.29.154.210";

        public DbConnection()
        {
            SqlConnection = new SqlConnection(connectionString);
        }

        internal SqlConnection SqlConnection { get; }
    }
}
