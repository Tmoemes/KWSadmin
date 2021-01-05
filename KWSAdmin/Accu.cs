using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using KWSAdmin;
using KWSAdmin.DALFactory;
using KWSAdmin.Persistence.Interface.Dtos;
using KWSAdmin.Persistence.Interface.Interfaces;

namespace KWSAdmin.Application 
{
    public class Accu
    {
        public int id { get; private set; }
        public string Name { get; private set; }
        public Account Creator { get; private set; }
        public string Specs { get; private set; }

        private static IAccuDal accuDal = AccuFactory.GetAccuDal();

        public Accu(AccuDto accu)
        {
            this.id = accu.id;
            this.Name = accu.Name;
            this.Creator = new Account(accu.Creator);
            this.Specs = accu.Specs;

        }


        public static List<Accu> GetAllAccus(SqlConnection Connection)
        {
            List<Accu> accuList = new List<Accu>();
            foreach (var accu in accuDal.GetAllAccus(Connection))
            {
                accuList.Add(new Accu(accu));
            }

            return accuList;
        }


    }
}
