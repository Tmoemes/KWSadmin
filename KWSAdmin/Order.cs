using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using KWSAdmin.Persistence.Interface.Dtos;
using KWSAdmin.Persistence.Interface.Interfaces;
using KWSAdmin.DALFactory;

namespace KWSAdmin.Application
{
    public class Order
    {
        public int Id { get; private set; }
        public Client Client { get; private set; } 
        public Location Location { get; private set; }
        public Account Creator { get; private set; }
        public Accu Accu { get; private set; }
        public string Info { get; private set; }
        public bool Done { get; set; }

        private readonly IOrderDal OrderDal = OrderFactory.GetOrderDal();
        private readonly IAccountDal UserDal = AccountFactory.GetUserDal();
        private readonly IAccuDal AccuDal = AccuFactory.GetAccuDal();
        private readonly IClientDal ClientDal = ClientFactory.GetClientDal();


        public Order(OrderDto order,SqlConnection connection)
        {
            this.Id = order.Id;
            this.Client = new Client(ClientDal.GetById(order.Clientid,connection)); 
            this.Location = order.Location;
            this.Creator = new Account(UserDal.GetById(order.Creatorid,connection)); 
            this.Accu = new Accu(AccuDal.GetById(order.Accuid,connection),connection);
            this.Info = order.Info;
            this.Done = order.Done;
        }

        public Order(int id, int clientid, Location location, int creatorid, int accuid, string info ,bool done , SqlConnection connection)
        {
            this.Id = id;
            this.Client = new Client(ClientDal.GetById(clientid, connection));
            this.Location = location;
            this.Creator = new Account(UserDal.GetById(creatorid, connection));
            this.Accu = new Accu(AccuDal.GetById(accuid, connection), connection);
            this.Info = info;
            this.Done = done;
        }

        //create order ctor
        public Order(int clientid , Location location , int creatorid , int accuid , string info, SqlConnection connection)
        {
            this.Client = new Client(ClientDal.GetById(clientid, connection));
            this.Location = location;
            this.Creator = new Account(UserDal.GetById(creatorid, connection));
            this.Accu = new Accu(AccuDal.GetById(accuid, connection), connection);
            this.Info = info;
        }

        public Order()
        {
            
        }

        public void AddOrder( SqlConnection connection)
        {
            OrderDal.Add(new OrderDto(Client.Id,Location,Creator.Id,Accu.Id,Info,Done), connection);
        }

        public List<Order> GetAllOrders(SqlConnection connection)
        {
            return OrderDal.GetAllOrders(connection).Select(order => new Order(order, connection)).ToList();
        }

        public Order GetById(int id, SqlConnection connection)
        {
            return new Order(OrderDal.GetById(id, connection),connection);
        }

        public void Delete(int id, SqlConnection connection)
        {
            OrderDal.DeleteOrder(id, connection);
        }

        public void Update(Order order, SqlConnection connection)
        {
            OrderDal.UpdateOrder(new OrderDto(order.Client.Id, order.Location, order.Creator.Id, order.Accu.Id, order.Info, order.Done), connection);
        }


    }
}
