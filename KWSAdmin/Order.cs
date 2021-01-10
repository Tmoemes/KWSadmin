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

        private readonly IOrderDal _orderDal = OrderFactory.GetOrderDal();
        


        public Order(OrderDto order)
        {
            this.Id = order.Id;
            this.Client = new Client().GetById(order.Clientid); 
            this.Location = order.Location;
            this.Creator = new Account().GetById(order.Creatorid); 
            this.Accu = new Accu().GetById(order.Accuid);
            this.Info = order.Info;
            this.Done = order.Done;
        }

        public Order(int id, Client client, Location location, Account creator, Accu accu, string info ,bool done)
        {
            this.Id = id;
            this.Client = client;
            this.Location = location;
            this.Creator = creator;
            this.Accu = accu;
            this.Info = info;
            this.Done = done;
        }

        //create order ctor
        public Order(int clientid , Location location , int creatorid , int accuid , string info)
        {
            this.Client = new Client().GetById(clientid);
            this.Location = location;
            this.Creator = new Account().GetById(creatorid);
            this.Accu = new Accu().GetById(accuid);
            this.Info = info;
            this.Done = false;
        }

        public Order()
        {
            
        }

        public void AddOrder()
        {
            _orderDal.Add(new OrderDto(Client.Id,Location,Creator.Id,Accu.Id,Info,Done));
        }

        public List<Order> GetAllOrders()
        {
            return _orderDal.GetAllOrders().Select(order => new Order(order)).ToList();
        }

        public Order GetById(int id)
        {
            return new Order(_orderDal.GetById(id));
        }

        public void Delete(int id)
        {
            _orderDal.DeleteOrder(id);
        }

        public void Update(Order order)
        {
            _orderDal.UpdateOrder(new OrderDto(order.Client.Id, order.Location, order.Creator.Id, order.Accu.Id, order.Info, order.Done));
        }


    }
}
