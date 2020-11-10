using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using KWSAdmin.Persistence.Interface.Dtos;

namespace KWSAdminApplication
{
    public class Client
    {
        public int id { get; private set; }
        public string FName { get; private set; }
        public string LName { get; private set; }
        public string Phone { get; private set; }
        public string EMail { get; private set; }
        public string Adres { get; private set; }

        public Client(ClientDto client)
        {
            this.id = client.id;
            this.FName = client.FName;
            this.LName = client.LName;
            this.Phone = client.Phone;
            this.EMail = client.EMail;
            this.Adres = client.Adres;

        }

    }
}
