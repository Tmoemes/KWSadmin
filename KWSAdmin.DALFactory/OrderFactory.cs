﻿using KWSAdmin.Persistence;
using KWSAdmin.Persistence.Interface.Interfaces;

namespace KWSAdmin.DALFactory
{
    public class OrderFactory
    {
        public static IOrderDal GetOrderDal()
        {
            return new OrderDal();
        }
    }
}
