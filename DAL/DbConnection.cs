using System;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;


namespace KWSAdmin.Persistence
{
    public class DbConnection
    {
        private readonly string connectionString = 
            "Data Source=Desktop-FG0G0NE;Initial Catalog=KwsAdmin;Integrated Security=True"; //todo deze uit appsetting halen


        public DbConnection()
        {
            SqlConnection = new SqlConnection(connectionString);
        }

        internal SqlConnection SqlConnection { get; }
    }
}
