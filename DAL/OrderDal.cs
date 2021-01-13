using KWSAdmin.Persistence.Interface.Dtos;
using KWSAdmin.Persistence.Interface.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace KWSAdmin.Persistence
{
    public class OrderDal : IOrderDal
    {

        private readonly SqlConnection _connection;

        public OrderDal()
        {
            _connection = DbConnection.GetConnection();
        }


        public bool AddOrder(OrderDto order)
        {
            try
            {
                _connection.Open();

                var cmd = new SqlCommand(
                    "INSERT INTO [Order] (locationid, clientid, creatorid, accuid, info, done) VALUES (@locationid, @clientid, @creatorid, @accuid, @info, @done)",
                    _connection);
                cmd.Parameters.AddWithValue("locationid", (int)order.Location);
                cmd.Parameters.AddWithValue("clientid", order.Clientid);
                cmd.Parameters.AddWithValue("accuid", order.Accuid);
                cmd.Parameters.AddWithValue("creatorid", order.Creatorid);
                cmd.Parameters.AddWithValue("info", order.Info ?? " ");
                cmd.Parameters.AddWithValue("@done", 0);

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

        public OrderDto GetOrderById(int id)
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
                    var order = new OrderDto(id, reader.GetInt32("clientid"), (Location)reader["locationid"],
                        reader.GetInt32("creatorid"), reader.GetInt32("accuid"), reader.GetString("info"),
                        Convert.ToBoolean(reader.GetInt32("done")));

                    return order;
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

        public bool UpdateOrder(OrderDto order)
        {
            try
            {
                _connection.Open();
                var cmd = new SqlCommand(
                    "UPDATE [Order] SET locationid = @locationid, clientid = @clientid, accuid = @accuid, creatorid = @creatorid, info = @info, done = @done WHERE id = @id;", _connection);
                cmd.Parameters.AddWithValue("@id", order.Id);
                cmd.Parameters.AddWithValue("@locationid", (int)order.Location);
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
                return false;
            }
            finally
            {
                _connection.Close();
            }

            return true;
        }

        public bool DeleteOrder(int id)
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
                return false;
            }
            finally
            {
                _connection.Close();
            }

            return true;
        }

        public List<OrderDto> GetAllOrders()
        {
            var dtolist = new List<OrderDto>();

            try
            {
                _connection.Open();

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

                    dtolist.Add(new OrderDto(id, clientid, (Location)locationid, userid, accuid, info,
                        done)); //todo kan beter met 1 stored procedure
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
    }
}
