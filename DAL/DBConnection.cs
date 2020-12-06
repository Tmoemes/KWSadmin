using System;
using System.Data.SqlClient;

namespace KWSAdmin.Persistence
{
    public class DbConnection
    {
        private readonly string connectionString =
            "Data Source=LAPTOP-GD4GJOLQ;Initial Catalog=KwsAdmin;Integrated Security=True";

        public DbConnection()
        {
            SqlConnection = new SqlConnection(connectionString);
        }

        internal SqlConnection SqlConnection { get; }
    }
}
