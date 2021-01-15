using KWSAdmin.DALFactory;
using KWSAdmin.Persistence.Interface.Dtos;
using KWSAdmin.Persistence.Interface.Interfaces;
using System.Collections.Generic;
using System.Linq;

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
            this.Client = new Client().GetClientById(order.Clientid);
            this.Location = order.Location;
            this.Creator = new Account().GetAccountById(order.Creatorid);
            this.Accu = new Accu().GetAccuById(order.Accuid);
            this.Info = order.Info;
            this.Done = order.Done;
        }

        public Order(int id, Client client, Location location, Account creator, Accu accu, string info, bool done)
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
        public Order(int clientid, Location location, int creatorid, int accuid, string info)
        {
            this.Client = new Client().GetClientById(clientid);
            this.Location = location;
            this.Creator = new Account().GetAccountById(creatorid);
            this.Accu = new Accu().GetAccuById(accuid);
            this.Info = info;
            this.Done = false;
        }

        public Order()
        {

        }

        public bool AddOrder()
        {
            return _orderDal.AddOrder(new OrderDto(Client.Id, Location, Creator.Id, Accu.Id, Info, Done));
        }

        public List<Order> GetAllOrders()
        {
            return _orderDal.GetAllOrders()?.Select(order => new Order(order)).ToList();
        }

        public Order GetOrderById(int id)
        {
            return new Order(_orderDal.GetOrderById(id));
        }

        public bool DeleteOrder(int id)
        {
            return _orderDal.DeleteOrder(id);
        }

        public bool UpdateOrder(Order order)
        {
            return _orderDal.UpdateOrder(new OrderDto(order.Id,order.Client.Id, order.Location, order.Creator.Id, order.Accu.Id, order.Info, order.Done));
        }

        public bool UpdateOrderLocation(int id, Location location)
        {
            return _orderDal.UpdateOrderLocation(id, location); 
        }


    }
}
