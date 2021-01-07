using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using KWSAdmin;
using KWSAdmin.DALFactory;
using KWSAdmin.Persistence.Interface.Dtos;
using KWSAdmin.Persistence.Interface.Interfaces;

namespace KWSAdmin.Application 
{
    public class Accu
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public Account Creator { get; private set; }
        public string Specs { get; private set; }

        private static readonly IAccuDal AccuDal = AccuFactory.GetAccuDal();
        private static readonly IAccountDal UserDal = AccountFactory.GetUserDal();

        public Accu(AccuDto accu,SqlConnection connection)
        {
            this.Id = accu.Id;
            this.Name = accu.Name;
            this.Creator = new Account(UserDal.GetById(accu.Creatorid,connection));
            this.Specs = accu.Specs;

        }

        public Accu(int id, string name, int creatorid, string specs, SqlConnection connection)
        {
            this.Id = id;
            this.Name = name;
            this.Creator = new Account(UserDal.GetById(creatorid, connection));
            this.Specs = specs;

        }

        public static List<Accu> GetAllAccus(SqlConnection connection)
        {
            return AccuDal.GetAllAccus(connection).Select(accu => new Accu(accu, connection)).ToList();
        }

        public static void AddAccu(Accu accu, SqlConnection connection)
        {
            AccuDal.Add(new AccuDto(0,accu.Name,accu.Creator.Id,accu.Specs),connection);

        }

        public override string ToString()
        {
            return Id + ": " + Name  ; 
        }
    }
}
