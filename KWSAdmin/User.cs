using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using KWSAdmin.Persistence.Interface.Dtos;
using KWSAdmin.Persistence.Interface.Interfaces;
using Interface;

namespace KWSAdmin
{
    public class User 
    {
        public int id { get; private set; }
        public string UserName { get; private set; }
        public string PassWord { get; private set; }
        public DateTime RegisterDate { get; private set; }

        public User()
        {

        }
    }
}
