using KWSAdmin.Persistence.Interface.Interfaces;
using KWSAdmin.Persistence.Interface.Dtos;
using System.Data.SqlClient;
using Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace KWSAdmin.Persistence
{
    public class OrderDal : IOrderDal
    {
        

        public void Add(OrderDto order, SqlConnection connection)
        {

            try
            {
                connection.Open();

                var cmd = new SqlCommand("INSERT INTO [Order] (locationid, clientid, creatorid, accuid, info) VALUES (@locationid, @clientid, @creatorid, @accuid, @info)",connection);
                cmd.Parameters.AddWithValue("locationid", (int)order.location);
                cmd.Parameters.AddWithValue("clientid", order.clientid);
                cmd.Parameters.AddWithValue("accuid", order.accuid);
                cmd.Parameters.AddWithValue("creatorid", order.creatorid);
                cmd.Parameters.AddWithValue("info", order.info);

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

        public OrderDto GetById(int id, SqlConnection connection)
        {
            try
            {
                connection.Open();

                var cmd = new SqlCommand("SELECT locationid,clientid,accuid,creatorid,info FROM [Order] WHERE id = @id",connection);
                cmd.Parameters.AddWithValue("@id", id);

                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var order = new OrderDto(id, reader.GetInt32("clientid"), (Location)reader["locationid"], reader.GetInt32("creatorid"), reader.GetInt32("accuid"), reader.GetString("info"));

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
                connection.Close();
            }

        }

        public void UpdateOrder(OrderDto order, SqlConnection connection)
        {

            try
            {
                connection.Open();
                var cmd = new SqlCommand(
                    "UPDATE [Order] SET locationid = @locationid, clientid = @clientid, accuid = @accuid, creatorid = @creatorid, info = @info WHERE id = @id",connection);
                cmd.Parameters.AddWithValue("@id", order.id);
                cmd.Parameters.AddWithValue("@locationid", (int) order.location);
                cmd.Parameters.AddWithValue("@clientid", order.clientid);
                cmd.Parameters.AddWithValue("@accuid", order.accuid);
                cmd.Parameters.AddWithValue("@creatorid", order.creatorid);
                cmd.Parameters.AddWithValue("@info", order.info);

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


        public List<OrderDto> GetAllOrders(SqlConnection connection)
        {
            var dtolist = new List<OrderDto>();

            try
            {
                connection.Open();
                var cmd = new SqlCommand("SELECT * FROM [Order]", connection);
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var id = reader.GetInt32("id");
                    var clientid = reader.GetInt32("clientid");
                    var locationid = reader.GetInt32("locationid");
                    var userid = reader.GetInt32("creatorid");
                    var accuid = reader.GetInt32("accuid");
                    var info = reader.GetString("info");

                    dtolist.Add(new OrderDto(id,clientid,(Location)locationid,userid,accuid,info));
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

    }
}
