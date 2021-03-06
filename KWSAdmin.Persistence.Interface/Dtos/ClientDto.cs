﻿namespace KWSAdmin.Persistence.Interface.Dtos
{
    public class ClientDto
    {
        public int Id { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Phone { get; private set; }
        public string EMail { get; private set; }
        public string Adres { get; private set; }

        public ClientDto(int id, string firstname, string lastname, string phone, string email, string adres)
        {
            this.Id = id;
            this.FirstName = firstname;
            this.LastName = lastname;
            this.Phone = phone;
            this.EMail = email;
            this.Adres = adres;
        }

        //ctor to add client
        public ClientDto(string firstname, string lastname, string phone, string email, string adres)
        {
            this.FirstName = firstname;
            this.LastName = lastname;
            this.Phone = phone;
            this.EMail = email;
            this.Adres = adres;
        }
    }
}
