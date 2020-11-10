using System;
using System.Collections.Generic;
using System.Text;
using KWSAdmin.Persistence;

namespace KWSAdmin.DALFactory
{
    public class UserFactory
    {
        public static UserDal GetUserDal()
        {
            return new UserDal();
        }

    }
}
