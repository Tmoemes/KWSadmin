using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Ini;


namespace AspView.Models
{
    public class DbConnection
    {
        private IConfiguration configuration;
        private SqlConnection con;

        public DbConnection()
        {
            con = sqlConnection();
        }

        private SqlConnection sqlConnection()
        {
            return new SqlConnection(configuration.GetConnectionString("ConnectionString"));
        }

        public SqlConnection GetConnection()
        {
            return con;
        }

    }
}
