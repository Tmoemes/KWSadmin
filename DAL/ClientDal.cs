using System;
using KWSAdmin.Persistence.Interface.Interfaces;
using KWSAdmin.Persistence.Interface.Dtos;
using Interface;
using System.Data.SqlClient;

namespace KWSAdmin.Persistence
{
    public class ClientDal : IClientDal
    {
        private readonly DbConnection _db;


        public ClientDal(DbConnection db)
        {
            _db = db;
        }

        public void Add(ClientDto client)
        {

            try
            {
                _db.SqlConnection.Open();

                var cmd = new SqlCommand(
                    "INSERT INTO Client (fname, lname, phone, email, adres) VALUES (@fname, @lname, @phone, @email, @adres)",
                    _db.SqlConnection);
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
                _db.SqlConnection.Close();
            }
        }

        public ClientDto GetById(int id)
        {
            try
            {
                _db.SqlConnection.Open();

                var cmd = new SqlCommand("SELECT fname,lname,phone,email,adres FROM Client WHERE id = @id", _db.SqlConnection);
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
                _db.SqlConnection.Close();
            }

        }

        public ClientDto GetByLName(string name)
        {
            try
            {
                _db.SqlConnection.Open();

                var cmd = new SqlCommand("SELECT id,fname,phone,email,adres FROM Client WHERE lname = @lname", _db.SqlConnection);
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
                _db.SqlConnection.Close();
            }

        }

        public void UpdateClient(ClientDto client)
        {

            try
            {
                _db.SqlConnection.Open();
                var cmd = new SqlCommand(
                    "UPDATE Client SET fname = @fname, lname = @lname, phone = @phone, email = @email, adres = @adres WHERE id = @id");
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
                _db.SqlConnection.Close();
            }

        }
    }
}
