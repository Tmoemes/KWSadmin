using System;
using System.Collections.Generic;
using System.Text;
using KWSAdmin.Persistence;

namespace KWSAdmin.Persistence.Interface.Dtos
{
    public class AccuDto
    {
        public int id { get; private set; }
        public string Name { get; private set; }
        public int Creatorid { get; private set; }
        public string Specs { get; private set; }

        public AccuDto(int id, string name, int creator, string specs)
        {
            this.id = id;
            this.Name = name;
            this.Creatorid = creator;
            this.Specs = specs;
        }
    }
}
