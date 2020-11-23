using System;
using System.Collections.Generic;
using System.Text;
using KWSAdmin.Persistence;

namespace KWSAdmin.DALFactory
{
    class AccuFactory
    {
        public static AccuDal GetUserDal()
        {
            return new AccuDal();
        }

    }
}
