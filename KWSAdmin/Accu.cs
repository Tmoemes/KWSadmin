using System;
using System.Collections.Generic;
using System.Text;
using KWSAdmin;
using KWSAdmin.Persistence.Interface.Dtos;

namespace KWSAdmin.Application 
{
    public class Accu
    {
        public int id { get; private set; }
        public string Name { get; private set; }
        public Account Creator { get; private set; }
        public string Specs { get; private set; }

        public Accu(AccuDto accu)
        {
            this.id = accu.id;
            this.Name = accu.Name;
            this.Creator = new Account(accu.Creator);
            this.Specs = accu.Specs;

        }
    }
}
