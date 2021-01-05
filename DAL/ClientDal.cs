using System;
using System.Collections.Generic;
using System.Data;
using KWSAdmin.Persistence.Interface.Interfaces;
using KWSAdmin.Persistence.Interface.Dtos;
using Interface;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace KWSAdmin.Persistence
{
    public class ClientDal : IClientDal
    {

        public void Add(ClientDto client, SqlConnection connection)
        {

            try
            {
                connection.Open();

                var cmd = new SqlCommand(
                    "INSERT INTO Client (fname, lname, phone, email, adres) VALUES (@fname, @lname, @phone, @email, @adres)",connection);
                cmd.Parameters.AddWithValue("@fname", client.FName);
                cmd.Parameters.AddWithValue("@lname", client.LName);
                cmd.Parameters.AddWithValue("@phone", client.Phone);
                cmd.Parameters.AddWithValue("@email", client.EMail);
                cmd.Parameters.AddWithValue("@adres", client.Adres);

                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                connection.Close();
            }
        }

        public List<ClientDto> GetAllClients(SqlConnection connection)
        {
            var dtolist = new List<ClientDto>();

            try
            {
                connection.Open();
                var cmd = new SqlCommand("SELECT * FROM [Client]", connection);
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var id = reader.GetInt32("id");
                    var fname = reader.GetString("fname");
                    var lname = reader.GetString("lname");
                    var phone = reader.GetString("phone");
                    var email = reader.GetString("email");
                    var adres = reader.GetString("adres");

                    dtolist.Add(new ClientDto(id,fname,lname,phone,email,adres));
                }

                return dtolist;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            finally
            {
                connection.Close();
            }
        }





        public ClientDto GetById(int id,SqlConnection connection)
        {
            try
            {
                connection.Open();

                var cmd = new SqlCommand("SELECT fname,lname,phone,email,adres FROM Client WHERE id = @id", connection);
                cmd.Parameters.AddWithValue("@id", id);

                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var client = new ClientDto(id,reader["fname"].ToString(),reader["lname"].ToString(),reader["phone"].ToString(),reader["email"].ToString(),reader["adres"].ToString());

                    return client;
                }

                return null;
            }

            catch (Exception noid)
            {
                Console.WriteLine(noid);
                throw;
            }
            finally
            {
                connection.Close();
            }

        }

        public ClientDto GetByLName(string name, SqlConnection connection)
        {
            try
            {
                connection.Open();

                var cmd = new SqlCommand("SELECT id,fname,phone,email,adres FROM Client WHERE lname = @lname", connection);
                cmd.Parameters.AddWithValue("@lname", name);

                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var client = new ClientDto((int)reader["id"], reader["fname"].ToString(), name, reader["phone"].ToString(), reader["email"].ToString(), reader["adres"].ToString());

                    return client;
                }

                return null;
            }

            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            finally
            {
                connection.Close();
            }

        }

        public void UpdateClient(ClientDto client, SqlConnection connection)
        {

            try
            {
                connection.Open();
                var cmd = new SqlCommand(
                    "UPDATE Client SET fname = @fname, lname = @lname, phone = @phone, email = @email, adres = @adres WHERE id = @id",connection);
                cmd.Parameters.AddWithValue("@id", client.id);
                cmd.Parameters.AddWithValue("@fname", client.FName);
                cmd.Parameters.AddWithValue("@lname", client.LName);
                cmd.Parameters.AddWithValue("@phone", client.Phone);
                cmd.Parameters.AddWithValue("@email", client.EMail);
                cmd.Parameters.AddWithValue("@adres", client.Adres);

                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            finally
            {
                connection.Close();
            }

        }
    }
}
