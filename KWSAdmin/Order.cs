using System;
using System.Collections.Generic;
using System.Text;
using KWSAdmin;
using KWSAdmin.Persistence.Interface.Dtos;

namespace KWSAdminApplication
{
    public class Order
    {
        public int id { get; private set; }
        public Client client { get; private set; } 
        public Location location { get; private set; }
        public User creator { get; private set; }
        public Accu accu { get; private set; }

        public Order()
        {

        }
    }
}
