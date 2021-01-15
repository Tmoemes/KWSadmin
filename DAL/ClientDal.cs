using KWSAdmin.Persistence.Interface.Dtos;
using KWSAdmin.Persistence.Interface.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace KWSAdmin.Persistence
{
    public class ClientDal : IClientDal
    {

        private readonly SqlConnection _connection;

        public ClientDal()
        {
            _connection = DbConnection.GetConnection();
        }


        public bool AddClient(ClientDto client)
        {

            try
            {
                _connection.Open();

                var cmd = new SqlCommand(
                    "INSERT INTO Client (fname, lname, phone, email, adres) VALUES (@fname, @lname, @phone, @email, @adres)", _connection);

                cmd.Parameters.AddWithValue("@fname", client.FirstName ?? " ");
                cmd.Parameters.AddWithValue("@phone", client.Phone ?? " ");
                cmd.Parameters.AddWithValue("@adres", client.Adres ?? " ");
                cmd.Parameters.AddWithValue("@lname", client.LastName);
                cmd.Parameters.AddWithValue("@email", client.EMail);

                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
            finally
            {
                _connection.Close();
            }

            return true;
        }

        public List<ClientDto> GetAllClients()
        {
            var dtolist = new List<ClientDto>();

            try
            {
                _connection.Open();
                var cmd = new SqlCommand("SELECT * FROM [Client]", _connection);
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var id = reader.GetInt32("id");
                    var fname = reader.GetString("fname");
                    var lname = reader.GetString("lname");
                    var phone = reader.GetString("phone");
                    var email = reader.GetString("email");
                    var adres = reader.GetString("adres");

                    dtolist.Add(new ClientDto(id, fname, lname, phone, email, adres));
                }

                return dtolist;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
            finally
            {
                _connection.Close();
            }
        }



        public ClientDto GetClientById(int id)
        {
            try
            {
                _connection.Open();

                var cmd = new SqlCommand("SELECT fname,lname,phone,email,adres FROM Client WHERE id = @id", _connection);
                cmd.Parameters.AddWithValue("@id", id);

                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var client = new ClientDto(id, reader["fname"].ToString(), reader["lname"].ToString(), reader["phone"].ToString(), reader["email"].ToString(), reader["adres"].ToString());

                    return client;
                }

                return null;
            }

            catch (Exception noid)
            {
                Console.WriteLine(noid);
                return null;
            }
            finally
            {
                _connection.Close();
            }

        }

        public ClientDto GetClientByLName(string name)
        {
            try
            {
                _connection.Open();

                var cmd = new SqlCommand("SELECT id,fname,phone,email,adres FROM Client WHERE lname = @lname", _connection);
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
                return null;
            }
            finally
            {
                _connection.Close();
            }

        }

        public bool UpdateClient(ClientDto client)
        {

            try
            {
                _connection.Open();
                var cmd = new SqlCommand(
                    "UPDATE Client SET fname = @fname, lname = @lname, phone = @phone, email = @email, adres = @adres WHERE id = @id", _connection);
                cmd.Parameters.AddWithValue("@id", client.Id);
                cmd.Parameters.AddWithValue("@fname", client.FirstName ?? " ");
                cmd.Parameters.AddWithValue("@lname", client.LastName);
                cmd.Parameters.AddWithValue("@phone", client.Phone ?? " ");
                cmd.Parameters.AddWithValue("@email", client.EMail);
                cmd.Parameters.AddWithValue("@adres", client.Adres ?? " ");

                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
            finally
            {
                _connection.Close();
            }

            return true;
        }


        public bool DeleteClient(int id)
        {

            try
            {
                _connection.Open();
                var cmd = new SqlCommand(
                    "DELETE FROM Client WHERE id = @id", _connection);
                cmd.Parameters.AddWithValue("@id", id);

                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
            finally
            {
                _connection.Close();
            }

            return true;
        }

    }
}
