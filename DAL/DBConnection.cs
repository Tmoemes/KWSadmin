using System;
using System.Data.SqlClient;

namespace KWSAdmin.Persistence
{
    public class DbConnection
    {
        // old connectionstring readonly string connectionString = "Persist Security Info=False;" + "User ID=KwsDatabase;" + "Password=KwsDatabase123;" + "Initial Catalog=KwsAdmin;" + "Server=84.29.154.210";
        private readonly string connectionString =
            "Server=LAPTOP-GD4GJOLQ;Database=KwsAdmin;User Id=Kws;Password=Kws123;";

        public DbConnection()
        {
            SqlConnection = new SqlConnection(connectionString);
        }

        internal SqlConnection SqlConnection { get; }
    }
}
