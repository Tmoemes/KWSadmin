using System;
using KWSAdmin.Persistence.Interface.Interfaces;
using KWSAdmin.Persistence.Interface.Dtos;
using Interface;
using System.Data.SqlClient;

namespace KWSAdmin.Persistence
{
    public class AccuDal : IAccuDal
    {
        private readonly DbConnection _db;
        UserDal userDal;

        public AccuDal(DbConnection db)
        {
            _db = db;
        }

        public void Add(AccuDto accu)
        {

            try
            {
                _db.SqlConnection.Open();

                var cmd = new SqlCommand("INSERT INTO Accu (name, creatorid, specs) VALUES (@name, @creatorid, @specs)", _db.SqlConnection);
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
                _db.SqlConnection.Close();
            }
        }

        public AccuDto GetById(int id)
        {
            try
            {
                _db.SqlConnection.Open();

                var cmd = new SqlCommand("SELECT name,creatorid,specs FROM Accu WHERE id = @id", _db.SqlConnection);
                cmd.Parameters.AddWithValue("@id", id);

                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var accu = new AccuDto(id, reader["name"].ToString(), userDal.GetById((int)reader["creator"]), reader["specs"].ToString().Split(","));

                    return accu;
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

        public void UpdateAccu(AccuDto accu)
        {

            try
            {
                _db.SqlConnection.Open();
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
                _db.SqlConnection.Close();
            }

        }


    }
}
