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


        public Order(OrderDto order)
        {
            this.id = order.id;
            this.client = new Client(order.client); 
            this.location = order.location;
            this.creator = new Account(order.creator); 
            this.accu = new Accu(order.accu);
            this.info = order.info;
        }

        public static void AddOrder(Order order, SqlConnection connection)
        {
            Client client = order.client;
            ClientDto clientDto = new ClientDto(client.id,client.FName,client.LName,client.Phone,client.EMail,client.Adres);
            Account creator = order.creator;
            UserDto creatorDto = new UserDto(creator.id,creator.username,creator.password,creator.admin);
            Accu accu = order.accu;
            Account accucreator = order.accu.Creator;
            UserDto accucreatorDto = new UserDto(accucreator.id,accucreator.username,accucreator.password,accucreator.admin);
            AccuDto accuDto = new AccuDto(accu.id,accu.Name,accucreatorDto,accu.Specs);

            orderDal.Add(new OrderDto(0,clientDto,order.location,creatorDto,accuDto,order.info), connection);
        }

        public static List<Order> GetAllOrders(SqlConnection connection)
        {
            List<Order> orderList = new List<Order>();
            foreach (var order in orderDal.GetAllOrders(connection))
            {
                orderList.Add(new Order(order));
            }

            return orderList;
        }

        


    }
}
