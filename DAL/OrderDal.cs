using KWSAdmin.Persistence.Interface.Interfaces;
using KWSAdmin.Persistence.Interface.Dtos;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace KWSAdmin.Persistence
{
    public class OrderDal : IOrderDal
    {

        private readonly SqlConnection _connection;

        public OrderDal()
        {
            _connection = DbConnection.GetConnection();
        }


        public void Add(OrderDto order)
        {
            try
            {
                _connection.Open();

                var cmd = new SqlCommand(
                    "INSERT INTO [Order] (locationid, clientid, creatorid, accuid, info, done) VALUES (@locationid, @clientid, @creatorid, @accuid, @info, @done)",
                    _connection);
                cmd.Parameters.AddWithValue("locationid", (int) order.Location);
                cmd.Parameters.AddWithValue("clientid", order.Clientid);
                cmd.Parameters.AddWithValue("accuid", order.Accuid);
                cmd.Parameters.AddWithValue("creatorid", order.Creatorid);
                cmd.Parameters.AddWithValue("info", order.Info ?? " ");
                cmd.Parameters.AddWithValue("@done", 0);

                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e); //todo gebruiker ziet hier niks van
            }
            finally
            {
                _connection.Close();
            }
        }

        public OrderDto GetById(int id)
        {
            try
            {
                _connection.Open();

                var cmd = new SqlCommand(
                    "SELECT locationid,clientid,accuid,creatorid,info,done FROM [Order] WHERE id = @id", _connection);
                cmd.Parameters.AddWithValue("@id", id);

                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var order = new OrderDto(id, reader.GetInt32("clientid"), (Location) reader["locationid"],
                        reader.GetInt32("creatorid"), reader.GetInt32("accuid"), reader.GetString("info"),
                        Convert.ToBoolean(reader.GetInt32("done")));

                    return order;
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

        public void UpdateOrder(OrderDto order)
        {
            try
            {
                _connection.Open();
                var cmd = new SqlCommand(
                    "UPDATE [Order] SET locationid = @locationid, clientid = @clientid, accuid = @accuid, creatorid = @creatorid, info = @info, done = @done WHERE id = @id;", _connection);
                cmd.Parameters.AddWithValue("@id", order.Id);
                cmd.Parameters.AddWithValue("@locationid", (int) order.Location);
                cmd.Parameters.AddWithValue("@clientid", order.Clientid);
                cmd.Parameters.AddWithValue("@accuid", order.Accuid);
                cmd.Parameters.AddWithValue("@creatorid", order.Creatorid);
                cmd.Parameters.AddWithValue("@info", order.Info ?? " ");
                cmd.Parameters.AddWithValue("@done", Convert.ToInt32(order.Done));

                cmd.ExecuteNonQuery();//todo database wordt hier niet geupdate
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

        public void DeleteOrder(int id)
        {
            try
            {
                _connection.Open();
                var cmd = new SqlCommand(
                    "DELETE FROM [Order] WHERE id = @id", _connection);
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

        public List<OrderDto> GetAllOrders()
        {
            var dtolist = new List<OrderDto>();

            try
            {
                _connection.Open();

                /*var ds = new DataSet();
                var cmd = new SqlCommand("EXEC SelectAllOrders", connection) {CommandType = CommandType.StoredProcedure};
                var da = new SqlDataAdapter(cmd);
                da.Fill(ds);

                foreach (var order in ds.Tables["Order"].Columns["id"].)
                {
                    
                }*/

                var cmd = new SqlCommand("SELECT * FROM [Order]", _connection);
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var id = reader.GetInt32("id");
                    var clientid = reader.GetInt32("clientid");
                    var locationid = reader.GetInt32("locationid");
                    var userid = reader.GetInt32("creatorid");
                    var accuid = reader.GetInt32("accuid");
                    var info = reader.GetString("info");
                    var done = Convert.ToBoolean(reader.GetInt32("done"));

                    dtolist.Add(new OrderDto(id, clientid, (Location) locationid, userid, accuid, info,
                        done)); //todo kan beter met 1 stored procedure
                }

                return dtolist;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                _connection.Close();
            }

            return null;
        }
    }
}
