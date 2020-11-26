using System;
using KWSAdmin.Persistence.Interface.Interfaces;
using KWSAdmin.Persistence.Interface.Dtos;
using System.Data.SqlClient;
using Interface;

namespace KWSAdmin.Persistence
{
    public class UserDal : IUserDal
    {

        private readonly DbConnection _db;


        public UserDal(DbConnection db)
        {
            _db = db;
        }
        public void Add(UserDto user)
        {

            try
            {           
                _db.SqlConnection.Open();

                var cmd = new SqlCommand("INSERT INTO User (id, username, password) VALUES (@id, @username, @password)", _db.SqlConnection);
                cmd.Parameters.AddWithValue("id", user.id);
                cmd.Parameters.AddWithValue("username", user.username);
                cmd.Parameters.AddWithValue("password", user.password);

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

        public UserDto GetById(int id)
        {
            try
            {
                _db.SqlConnection.Open();

                var cmd = new SqlCommand("SELECT username,password FROM User WHERE id = @id", _db.SqlConnection);
                cmd.Parameters.AddWithValue("id", id);

                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var user = new UserDto(id,reader["username"].ToString(),reader["password"].ToString());

                    return user;
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

        public void UpdateUser(UserDto user)
        {

            try
            {
                _db.SqlConnection.Open();
                var cmd = new SqlCommand(
                    "UPDATE User SET username = @username, password = @password WHERE id = @id");
                cmd.Parameters.AddWithValue("id", user.id);
                cmd.Parameters.AddWithValue("username", user.username);
                cmd.Parameters.AddWithValue("password", user.password);

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
