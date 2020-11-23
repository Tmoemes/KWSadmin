using System.Data.SqlClient;
using System.IO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace KWSAdmin.Persistence
{
    class DBConnection
    {
        
        private static void OpenSqlConnection()
        {
            string connectionString = "Data Source = 84.29.154.210; " +
                  "Initial Catalog=KwsAdmin;" +
                  "User id=KwsDatabase;" +
                  "Password=KwsDatabase123;";
            
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                Console.WriteLine("ServerVersion: {0}", connection.ServerVersion);
                Console.WriteLine("State: {0}", connection.State);
            }



        }
    }
}
