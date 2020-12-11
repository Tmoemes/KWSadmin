using System;
using System.Collections.Generic;
using System.Text;
using KWSAdmin.Persistence;

namespace KWSAdmin.DALFactory
{
    public class ClientFactory
        {
        public static ClientDal GetClientDal()
        {
            return new ClientDal(new DbConnection());
        }
    }
}
