using System;
using System.Collections.Generic;
using System.Text;
using KWSAdmin.Persistence;

namespace KWSAdmin.DALFactory
{
    class ClientFactory
    {
        public static ClientDal GetUserDal()
        {
            return new ClientDal();
        }
    }
}
