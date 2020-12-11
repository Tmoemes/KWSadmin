using KWSAdmin.Persistence.Interface.Interfaces;
using KWSAdmin.Persistence.Interface.Dtos;
using System.Data.SqlClient;
using Interface;
using System;

namespace KWSAdmin.Persistence
{
    public class OrderDal : IOrderDal
    {
        private readonly DbConnection _db;
        ClientDal clientDal;
        AccountDal userDal;
        AccuDal accuDal;



        public OrderDal(DbConnection db)
        {
            _db = db;
        }

        public void Add(OrderDto order)
        {

            try
            {
                _db.SqlConnection.Open();

                var cmd = new SqlCommand("INSERT INTO Order (locationid, clientid, creatorid, accuid, info) VALUES (@locationid, @clientid, @creatorid, @accuid, @info)", _db.SqlConnection);
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
                _db.SqlConnection.Close();
            }
        }

        public OrderDto GetById(int id)
        {
            try
            {
                _db.SqlConnection.Open();

                var cmd = new SqlCommand("SELECT locationid,clientid,accuid,creatorid,info FROM Order WHERE id = @id", _db.SqlConnection);
                cmd.Parameters.AddWithValue("@id", id);

                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var order = new OrderDto((int)reader["id"], clientDal.GetById((int)reader["clientid"]), (Location)reader["locationid"], userDal.GetById((int)reader["creatorid"]), accuDal.GetById((int)reader["accuid"]), reader["info"].ToString());

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
                _db.SqlConnection.Close();
            }

        }

        public void UpdateOrder(OrderDto order)
        {

            try
            {
                _db.SqlConnection.Open();
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
                _db.SqlConnection.Close();
            }

        }
    }
}
