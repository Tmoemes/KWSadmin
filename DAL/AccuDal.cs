using System;
using System.Collections.Generic;
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

        public List<AccuDto> GetAllAccus(SqlConnection connection)
        {
            var dtolist = new List<AccuDto>();
            var templist = new List<TempAccu>();

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

                    templist.Add(new TempAccu(id, name, creatorid, specs));
                }
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

            foreach (var accu in templist)
            {
                dtolist.Add(new AccuDto(accu.id,accu.name,userDal.GetById(accu.creatorid,connection),accu.specs));
            }


            return dtolist;
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
