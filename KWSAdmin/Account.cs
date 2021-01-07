using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using KWSAdmin.Persistence.Interface.Dtos;
using KWSAdmin.Persistence.Interface.Interfaces;
using KWSAdmin.DALFactory;
using KWSAdmin.Persistence;
using Microsoft.AspNetCore.Identity;

namespace KWSAdmin.Application
{
    public class Account 
    {
        public int Id { get; private set; }
        public string Username { get; private set; } 
        public string Password { get; private set; }
        public bool Admin { get; private set; }

        public Account(AccountDto account)
        {
            this.Id = account.Id;
            this.Username = account.Username;
            this.Password = account.Password;
            this.Admin = account.Admin;
        }

        public Account(int id,string username, string password, bool admin)
        {
            this.Id = id;
            this.Username = username; 
            this.Password = password;
            this.Admin = admin;
        }

        private static readonly IAccountDal Dal = AccountFactory.GetUserDal();

        public static Account GetByName(string name,SqlConnection connection)
        {
            return new Account(Dal.GetByName(name,connection));
        }

        public static int AddAccount(Account account, SqlConnection connection)
        {
            Dal.Add(new AccountDto(0,account.Username,account.Password,account.Admin), connection);

            return Dal.GetByName(account.Username, connection).Id;
        }

        public void SetHashedPw(string hashPw)
        {
            Password = hashPw;
        }

    }
}
