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
        public string username { get; private set; }
        public string password { get; private set; }
        public DateTime registerDate { get; private set; }

        public User(UserDto user)
        {
            this.id = user.id;
            this.username = user.username;
            this.password = user.password;
            this.registerDate = user.registerDate;
        }

        public bool verifyLogin(string username, string password)
        {
            if (username == this.username)
            {
                if (password == this.password)
                {
                    return true;
                }
                else throw new Exception("Username or Password is not correct");
            }
            return false;
        }
    }
}
