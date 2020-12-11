using System;
using System.Collections.Generic;
using System.Text;
using KWSAdmin.Persistence;
using KWSAdmin.Persistence.Interface.Interfaces;

namespace KWSAdmin.DALFactory
{
    public class AccountFactory
    {
        public static IUserDal GetUserDal()
        {
            return new AccountDal(new DbConnection());
        }
    }
}
