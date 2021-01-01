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
        public UserDto Creator { get; private set; }
        public string Specs { get; private set; }

        public AccuDto(int id, string name, UserDto creator, string specs)
        {
            this.id = id;
            this.Name = name;
            this.Creator = creator;
            this.Specs = specs;
        }
    }
}
