using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Text;
using Interface;
using KWSAdmin;
using KWSAdmin.Persistence.Interface.Dtos;
using KWSAdmin.Persistence.Interface.Interfaces;
using KWSAdmin.DALFactory;

namespace KWSAdmin.Application
{
    public class Order
    {
        public int id { get; private set; }
        public Client client { get; private set; } 
        public Location location { get; private set; }
        public Account creator { get; private set; }
        public Accu accu { get; private set; }
        public string info { get; private set; }

        private static IOrderDal orderDal = OrderFactory.GetOrderDal();
        private static IUserDal userDal = AccountFactory.GetUserDal();
        private static IAccuDal accuDal = AccuFactory.GetAccuDal();
        private static IClientDal clientDal = ClientFactory.GetClientDal();


        public Order(OrderDto order,SqlConnection connection)
        {
            this.id = order.id;
            this.client = new Client(clientDal.GetById(order.clientid,connection)); 
            this.location = order.location;
            this.creator = new Account(userDal.GetById(order.creatorid,connection)); 
            this.accu = new Accu(accuDal.GetById(order.accuid,connection),connection);
            this.info = order.info;
        }

        public Order(int id, int clientid, Location location, int creatorid, int accuid, string info , SqlConnection connection)
        {
            this.id = id;
            this.client = new Client(clientDal.GetById(clientid, connection));
            this.location = location;
            this.creator = new Account(userDal.GetById(creatorid, connection));
            this.accu = new Accu(accuDal.GetById(accuid, connection), connection);
            this.info = info;
        }


        public static void AddOrder(Order order, SqlConnection connection)
        {
            orderDal.Add(new OrderDto(0,order.client.id,order.location,order.creator.id,order.accu.id,order.info), connection);
        }

        public static List<Order> GetAllOrders(SqlConnection connection)
        {
            List<Order> orderList = new List<Order>();
            foreach (var order in orderDal.GetAllOrders(connection))
            {
                orderList.Add(new Order(order,connection));
            }

            return orderList;
        }

        public static Order GetById(int id, SqlConnection connection)
        {
            return new Order(orderDal.GetById(id, connection),connection);
        }


    }
}
