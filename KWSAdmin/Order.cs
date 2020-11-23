using System;
using System.Collections.Generic;
using System.Text;
using Interface;
using KWSAdmin;
using KWSAdmin.Persistence.Interface.Dtos;
using KWSAdmin.Persistence.Interface.Interfaces;
using KWSAdmin.DALFactory;

namespace KWSAdminApplication
{
    public class Order
    {
        public int id { get; private set; }
        public Client client { get; private set; } 
        public Location location { get; private set; }
        public User creator { get; private set; }
        public Accu accu { get; private set; }

        public Order(OrderDto order)
        {
            this.id = order.id;
            this.client = new Client(order.client); 
            this.location = order.location;
            this.creator = new User(order.creator); 
            this.accu = new Accu(order.accu); 
        }



        public void test()
        {
            IOrderDal dal = OrderFactory.GetOrderDal();

        }

        


    }
}
