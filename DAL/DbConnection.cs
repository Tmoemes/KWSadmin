﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace KWSAdmin.Persistence
{
    public class DbConnection
    {

        private static readonly SqlConnection SqlConnection = new SqlConnection(GetConnectionString());


        private static string GetConnectionString()
        {
            var builder = new
                ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json",
                optional: true, reloadOnChange: true);

            return builder.Build().GetConnectionString("ConnectionString");
        }


        public static SqlConnection GetConnection()
        {
            return SqlConnection;
        }


    }
}
