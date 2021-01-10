using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using KWSAdmin.Persistence.Interface.Dtos;
using KWSAdmin.Persistence.Interface.Interfaces;
using KWSAdmin.DALFactory;

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

        public Account(string username, string password, bool admin)
        {
            this.Username = username;
            this.Password = password;
            this.Admin = admin;
        }

        public Account()
        {
            
        }

        private static readonly IAccountDal _AccountDal = AccountFactory.GetUserDal();

        public Account GetByName(string name)
        {
            AccountDto accountDto = _AccountDal.GetByName(name);
            return accountDto == null ? null : new Account(accountDto);
        }

        public void AddAccount()
        {
            _AccountDal.Add(new AccountDto(0,Username,Password,Admin));
        }

        public Account GetById(int id)
        {
           return new Account(_AccountDal.GetById(id));

        }

        public void SetHashedPw(string hashPw)
        {
            Password = hashPw;
        }

    }
}
