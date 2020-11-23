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
        UserDal userDal;
        AccuDal accuDal;



        public OrderDal(DbConnection db)
        {
            _db = db;
        }

        public void Add(OrderDto order)
        {
            throw new System.NotImplementedException();
        }

        public OrderDto GetById(int id)
        {
            try
            {
                _db.SqlConnection.Open();

                var cmd = new SqlCommand("SELECT [locationid],[clientid],[accuid],[creatorid] FROM [Orders] WHERE [id] = @id", _db.SqlConnection);
                cmd.Parameters.Add(new SqlParameter("id", id));

                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var order = new OrderDto((int)reader["id"], clientDal.GetById((int)reader["clientid"]), (Location)reader["locationid"], userDal.GetById((int)reader["creatorid"]), accuDal.GetById((int)reader["accuid"]));

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

        public void updateorder(OrderDto order)
        {

            try
            {
                _db.SqlConnection.Open();
                var cmd = new SqlCommand("update [Orders] SET ");
            }

            throw new System.NotImplementedException();
        }
    }
}
