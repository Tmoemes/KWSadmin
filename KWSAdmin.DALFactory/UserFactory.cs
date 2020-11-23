using System;
using System.Collections.Generic;
using System.Text;
using KWSAdmin.Persistence;
using KWSAdmin.Persistence.Interface.Interfaces;

namespace KWSAdmin.DALFactory
{
    public class UserFactory
    {
        public static IUserDal GetUserDal()
        {
            return new UserDal();
        }

    }
}
