using System;
using System.Collections.Generic;
using System.Text;
using KWSAdmin;
using KWSAdmin.Persistence.Interface.Dtos;

namespace KWSAdminApplication
{
    public class Accu
    {
        public int id { get; private set; }
        public string Name { get; private set; }
        public User Creator { get; private set; }
        public string[] Specs { get; private set; }

        public Accu()
        {

        }
    }
}
