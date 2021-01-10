﻿using System;
using System.Data;
using KWSAdmin.Persistence.Interface.Interfaces;
using KWSAdmin.Persistence.Interface.Dtos;
using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;

namespace KWSAdmin.Persistence
{
    public class AccountDal : IAccountDal
    {

        private readonly SqlConnection _connection;

        public AccountDal()
        {
            _connection = DbConnection.GetConnection();
        }

        public void Add(AccountDto account)
        {
            try
            {           
                _connection.Open();

                var cmd = new SqlCommand("INSERT INTO Account (username, password, admin) VALUES (@username, @password, @admin)",_connection);
                cmd.Parameters.AddWithValue("@username", account.Username);
                cmd.Parameters.AddWithValue("@password", account.Password);
                cmd.Parameters.AddWithValue("@admin", Convert.ToInt32(account.Admin));

                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                _connection.Close();
            }
        }

        public AccountDto GetById(int id)
        {
            try
            {
                _connection.Open();

                var cmd = new SqlCommand("SELECT username,password,admin FROM Account WHERE id = @id",_connection);
                cmd.Parameters.AddWithValue("@id", id);

                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var username = reader.GetString("username");
                    var password = reader.GetString("password");

                   var user = new AccountDto(id,username,password,Convert.ToBoolean(reader.GetInt32("admin")));

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
                _connection.Close();
            }

        }

        public AccountDto GetByName(string name)
        {
            try
            {
                _connection.Open();

                var cmd = new SqlCommand("SELECT id,password,admin FROM Account WHERE username = @username",_connection);
                cmd.Parameters.AddWithValue("@username", name);

                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var user = new AccountDto((int)reader["id"],name, reader["password"].ToString(),Convert.ToBoolean(reader["admin"]));
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
                _connection.Close();
            }

        }

        public void UpdateUser(AccountDto account)
        {

            try
            {
                _connection.Open();
                var cmd = new SqlCommand(
                    "UPDATE Account SET username = @username, password = @password WHERE id = @id", _connection);
                cmd.Parameters.AddWithValue("@id", account.Id);
                cmd.Parameters.AddWithValue("@username", account.Username);
                cmd.Parameters.AddWithValue("@password", account.Password);

                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            finally
            {
                _connection.Close();
            }
        }

        public void DeleteAccount(int id)
        {

                try
                {
                    _connection.Open();
                    var cmd = new SqlCommand(
                        "DELETE FROM Account WHERE id = @id", _connection);
                    cmd.Parameters.AddWithValue("@id", id);

                    cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
                finally
                {
                    _connection.Close();
                }

        }

    }
}
