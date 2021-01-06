using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using KWSAdmin;
using KWSAdmin.DALFactory;
using KWSAdmin.Persistence.Interface.Dtos;
using KWSAdmin.Persistence.Interface.Interfaces;
using Microsoft.AspNetCore.Localization;

namespace KWSAdmin.Application 
{
    public class Accu
    {
        public int id { get; private set; }
        public string Name { get; private set; }
        public Account Creator { get; private set; }
        public string Specs { get; private set; }

        private static IAccuDal accuDal = AccuFactory.GetAccuDal();
        private static IUserDal userDal = AccountFactory.GetUserDal();

        public Accu(AccuDto accu,SqlConnection connection)
        {
            this.id = accu.id;
            this.Name = accu.Name;
            this.Creator = new Account(userDal.GetById(accu.Creatorid,connection));
            this.Specs = accu.Specs;

        }

        public Accu(int id, string name, int creatorid, string specs, SqlConnection connection)
        {
            this.id = id;
            this.Name = name;
            this.Creator = new Account(userDal.GetById(creatorid, connection));
            this.Specs = specs;

        }

        public static List<Accu> GetAllAccus(SqlConnection connection)
        {
            List<Accu> accuList = new List<Accu>();
            foreach (var accu in accuDal.GetAllAccus(connection))
            {
                accuList.Add(new Accu(accu,connection));
            }

            return accuList;
        }

        public static void AddAccu(Accu accu, SqlConnection connection)
        {
            accuDal.Add(new AccuDto(0,accu.Name,accu.Creator.id,accu.Specs),connection);

        }

        public override string ToString()
        {
            return id + ": " + Name  ; 
        }
    }
}
