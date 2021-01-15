using KWSAdmin.DALFactory;
using KWSAdmin.Persistence.Interface.Dtos;
using KWSAdmin.Persistence.Interface.Interfaces;
using System.Collections.Generic;
using System.Linq;

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
            this.Creator = new Account().GetAccountById(accu.Creatorid);
            this.Specs = accu.Specs;

        }

        public Accu(string name, int creatorid, string specs)
        {
            this.Name = name;
            this.Creator = new Account().GetAccountById(creatorid);
            this.Specs = specs;

        }

        public Accu(int id,string name, int creatorid, string specs)
        {
            this.Id = id;
            this.Name = name;
            this.Creator = new Account().GetAccountById(creatorid);
            this.Specs = specs;

        }

        public Accu()
        {

        }

        public List<Accu> GetAllAccus()
        {

            return (_accuDal.GetAllAccus().Select(accu => new Accu(accu)).ToList() ?? null);
        }

        public bool AddAccu(Accu accu)
        {
            return _accuDal.AddAccu(new AccuDto(0, accu.Name, accu.Creator.Id, accu.Specs));

        }

        public Accu GetAccuById(int id)
        {
            return new Accu(_accuDal.GetAccuById(id));
        }

        public bool UpdateAccu(Accu accu)
        {
            return _accuDal.UpdateAccu(new AccuDto(accu.Id,accu.Name,accu.Creator.Id,accu.Specs));
        }

    }
}
