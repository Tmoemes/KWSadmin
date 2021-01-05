﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using KWSAdmin.Persistence.Interface.Dtos;
using KWSAdmin.Persistence.Interface.Interfaces;
using Interface;
using KWSAdmin.DALFactory;
using KWSAdmin.Persistence;
using Microsoft.AspNetCore.Identity;

namespace KWSAdmin.Application
{
    public class Account 
    {
        public int id { get; private set; }
        public string username { get; private set; } 
        public string password { get; private set; }
        public bool admin { get; private set; }

        public Account(UserDto user)
        {
            this.id = user.id;
            this.username = user.username;
            this.password = user.password;
            this.admin = user.admin;
        }

        public Account(int id,string username, string password, bool admin)
        {
            this.id = id;
            this.username = username; 
            this.password = password;
            this.admin = admin;
        }

        private static IUserDal dal = AccountFactory.GetUserDal();

        public static Account GetByName(string name,SqlConnection connection)
        {
            return new Account(dal.GetByName(name,connection));
        }

        public static int AddUser(Account user, SqlConnection connection)
        {
            dal.Add(new UserDto(0,user.username,user.password,user.admin), connection);

            return dal.GetByName(user.username, connection).id;
        }

        public void SetHashedPw(string hashPw)
        {
            password = hashPw;
        }

    }
}
