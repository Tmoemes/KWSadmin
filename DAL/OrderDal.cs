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
        private readonly ClientDal _clientDal = new ClientDal();
        private readonly AccountDal _userDal = new AccountDal();
        private readonly AccuDal _accuDal = new AccuDal();


        public void Add(OrderDto order, SqlConnection connection)
        {

            try
            {
                connection.Open();

                var cmd = new SqlCommand("INSERT INTO Order (locationid, clientid, creatorid, accuid, info) VALUES (@locationid, @clientid, @creatorid, @accuid, @info)");
                cmd.Parameters.AddWithValue("locationid", (int)order.location);
                cmd.Parameters.AddWithValue("clientid", order.client.id);
                cmd.Parameters.AddWithValue("accuid", order.accu.id);
                cmd.Parameters.AddWithValue("creatorid", order.creator.id);
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

                var cmd = new SqlCommand("SELECT locationid,clientid,accuid,creatorid,info FROM Order WHERE id = @id",connection);
                cmd.Parameters.AddWithValue("@id", id);

                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var order = new OrderDto((int)reader["id"], _clientDal.GetById((int)reader["clientid"], connection), (Location)reader["locationid"], _userDal.GetById((int)reader["creatorid"], connection), _accuDal.GetById((int)reader["accuid"], connection), reader["info"].ToString());

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
                    "UPDATE Order SET locationid = @locationid, clientid = @clientid, accuid = @accuid, creatorid = @creatorid, info = @info WHERE id = @id");
                cmd.Parameters.AddWithValue("@id", order.id);
                cmd.Parameters.AddWithValue("@locationid", (int) order.location);
                cmd.Parameters.AddWithValue("@clientid", order.client.id);
                cmd.Parameters.AddWithValue("@accuid", order.accu.id);
                cmd.Parameters.AddWithValue("@creatorid", order.creator.id);
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
            var templist = new List<TempOrder>();

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

                    templist.Add(new TempOrder(id,locationid,clientid,userid,accuid,info));
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


            foreach (var tOrder in templist)
            {
                dtolist.Add(orderMapper(tOrder.id,tOrder.clientid,tOrder.locationid,tOrder.creatorid,tOrder.accuid,tOrder.info,connection));
            }

            return dtolist;
        }


        private OrderDto orderMapper(int id, int clientid, int locationid, int userid, int accuid, string info, SqlConnection connection)
        {
            var client = _clientDal.GetById(clientid, connection);
            var location = (Location)locationid;
            var user = _userDal.GetById(userid, connection);
            var accu = _accuDal.GetById(accuid, connection);

            return new OrderDto(id,client,location,user,accu,info);
        }


    }
}
