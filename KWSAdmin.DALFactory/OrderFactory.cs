using System;
using System.Collections.Generic;
using System.Text;
using KWSAdmin.Persistence;

namespace KWSAdmin.DALFactory
{
    public class OrderFactory
    {
        public static OrderDal GetOrderDal()
        {
            return new OrderDal();
        }
    }
}
