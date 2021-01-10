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

        private readonly IAccuDal _accuDal = AccuFactory.GetAccuDal();

        public Accu(AccuDto accu)
        {
            this.Id = accu.Id;
            this.Name = accu.Name;
            this.Creator = new Account().GetById(accu.Creatorid);
            this.Specs = accu.Specs;

        }

        public Accu(string name, int creatorid, string specs)
        {
            this.Name = name;
            this.Creator = new Account().GetById(creatorid);
            this.Specs = specs;

        }

        public Accu()
        {
            
        }

        public List<Accu> GetAllAccus()
        {
            return _accuDal.GetAllAccus().Select(accu => new Accu(accu)).ToList();
        }

        public void AddAccu(Accu accu)
        {
            _accuDal.Add(new AccuDto(0,accu.Name,accu.Creator.Id,accu.Specs));

        }

        public Accu GetById(int id)
        {
            return new Accu(_accuDal.GetById(id));
        }

        public override string ToString()
        {
            return Id + ": " + Name  ; 
        }
    }
}
