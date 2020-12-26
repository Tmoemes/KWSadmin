using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace AspView.Models
{
    public class DatabaseConnection
    {

        //todo op deze mannier moet waarschijnlijk sqlconnection naar dal meegegeven worden maar dan moet dit bij elke functie toegevoegd worden.
        private SqlConnection con;

        public DatabaseConnection()
        {
            IConfigurationRoot configuration = getConfiguration();

            con = new SqlConnection(configuration.GetConnectionString("ConnectionString"));
        }

        private IConfigurationRoot getConfiguration() 
        {
            IConfigurationBuilder builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json",true,true);
            return builder.Build();
        }
    }
}
