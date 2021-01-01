using System;
using System.Data;
using KWSAdmin.Persistence.Interface.Interfaces;
using KWSAdmin.Persistence.Interface.Dtos;
using Interface;
using System.Data.SqlClient;

namespace KWSAdmin.Persistence
{
    public class AccuDal : IAccuDal
    {
        AccountDal userDal = new AccountDal();

        public void Add(AccuDto accu,SqlConnection connection)
        {

            try
            {
                connection.Open();

                var cmd = new SqlCommand("INSERT INTO Accu (name, creatorid, specs) VALUES (@name, @creatorid, @specs)");
                cmd.Parameters.AddWithValue("@name", accu.Name);
                cmd.Parameters.AddWithValue("@creatorid", accu.Creator.id);
                cmd.Parameters.AddWithValue("@specs", string.Join(",", accu.Specs));

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

        public AccuDto GetById(int id,SqlConnection connection)
        {
            string name = "";
            int userid = 1;
            string specs = "";

            try
            {
                connection.Open();

                var cmd = new SqlCommand("SELECT name,creatorid,specs FROM Accu WHERE id = @id",connection);
                cmd.Parameters.AddWithValue("@id", id);

                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    name = reader.GetString("name");
                    userid = reader.GetInt32("creatorid");
                    specs = reader.GetString("specs");
                }
                connection.Close();

                return new AccuDto(id, name, userDal.GetById(userid, connection), specs);
            }

            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }


        }

        public void UpdateAccu(AccuDto accu, SqlConnection connection)
        {

            try
            {
                connection.Open();
                var cmd = new SqlCommand(
                    "UPDATE Accu SET name = @name, creatorid = @creatorid, specs = @specs WHERE id = @id");
                cmd.Parameters.AddWithValue("@id", accu.id);
                cmd.Parameters.AddWithValue("@name", accu.Name);
                cmd.Parameters.AddWithValue("@creatorid", accu.Creator.id);
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
