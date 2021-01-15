using KWSAdmin.Persistence.Interface.Dtos;
using KWSAdmin.Persistence.Interface.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace KWSAdmin.Persistence
{
    public class AccuDal : IAccuDal
    {

        private readonly SqlConnection _connection;

        public AccuDal()
        {
            _connection = DbConnection.GetConnection();
        }

        public bool AddAccu(AccuDto accu)
        {

            try
            {
                _connection.Open();

                var cmd = new SqlCommand("INSERT INTO Accu (name, creatorid, specs) VALUES (@name, @creatorid, @specs)", _connection);
                cmd.Parameters.AddWithValue("@name", accu.Name);
                cmd.Parameters.AddWithValue("@creatorid", accu.Creatorid);
                cmd.Parameters.AddWithValue("@specs", accu.Specs ?? " ");

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

        public List<AccuDto> GetAllAccus()
        {
            var dtolist = new List<AccuDto>();

            try
            {
                _connection.Open();
                var cmd = new SqlCommand("SELECT * FROM [Accu]", _connection);
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var id = reader.GetInt32("id");
                    var name = reader.GetString("name");
                    var creatorid = reader.GetInt32("creatorid");
                    var specs = reader.GetString("specs");

                    dtolist.Add(new AccuDto(id, name, creatorid, specs));
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


        public AccuDto GetAccuById(int id)
        {
            try
            {
                _connection.Open();

                var cmd = new SqlCommand("SELECT name,creatorid,specs FROM Accu WHERE id = @id", _connection);
                cmd.Parameters.AddWithValue("@id", id);

                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    return new AccuDto(id, reader.GetString("name"), reader.GetInt32("creatorid"), reader.GetString("specs"));
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

        public bool UpdateAccu(AccuDto accu)
        {

            try
            {
                _connection.Open();
                var cmd = new SqlCommand(
                    "UPDATE Accu SET name = @name, creatorid = @creatorid, specs = @specs WHERE id = @id", _connection);
                cmd.Parameters.AddWithValue("@id", accu.Id);
                cmd.Parameters.AddWithValue("@name", accu.Name);
                cmd.Parameters.AddWithValue("@creatorid", accu.Creatorid);
                cmd.Parameters.AddWithValue("@specs", accu.Specs ?? " ");

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

        public bool DeleteAccu(int id)
        {

            try
            {
                _connection.Open();
                var cmd = new SqlCommand(
                    "DELETE FROM Accu WHERE id = @id", _connection);
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
