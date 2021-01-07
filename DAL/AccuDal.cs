using System;
using System.Collections.Generic;
using System.Data;
using KWSAdmin.Persistence.Interface.Interfaces;
using KWSAdmin.Persistence.Interface.Dtos;
using System.Data.SqlClient;

namespace KWSAdmin.Persistence
{
    public class AccuDal : IAccuDal
    {

        public void Add(AccuDto accu,SqlConnection connection)
        {

            try
            {
                connection.Open();

                var cmd = new SqlCommand("INSERT INTO Accu (name, creatorid, specs) VALUES (@name, @creatorid, @specs)",connection);
                cmd.Parameters.AddWithValue("@name", accu.Name);
                cmd.Parameters.AddWithValue("@creatorid", accu.Creatorid);
                cmd.Parameters.AddWithValue("@specs", accu.Specs);

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

        public List<AccuDto> GetAllAccus(SqlConnection connection)
        {
            var dtolist = new List<AccuDto>();

            try
            {
                connection.Open();
                var cmd = new SqlCommand("SELECT * FROM [Accu]", connection);
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
                throw;
            }
            finally
            {
                connection.Close();
               
            }
        }


        public AccuDto GetById(int id,SqlConnection connection)
        {
            try
            {
                connection.Open();

                var cmd = new SqlCommand("SELECT name,creatorid,specs FROM Accu WHERE id = @id", connection);
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
                throw;
            }
            finally
            {
                connection.Close();
            }


        }

        public void UpdateAccu(AccuDto accu, SqlConnection connection)
        {

            try
            {
                connection.Open();
                var cmd = new SqlCommand(
                    "UPDATE Accu SET name = @name, creatorid = @creatorid, specs = @specs WHERE id = @id",connection);
                cmd.Parameters.AddWithValue("@id", accu.Id);
                cmd.Parameters.AddWithValue("@name", accu.Name);
                cmd.Parameters.AddWithValue("@creatorid", accu.Creatorid);
                cmd.Parameters.AddWithValue("@specs", string.Join(",", accu.Specs));

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
