using System;
using System.Collections.Generic;
using System.Data;
using System.Net.Http;
using System.Text;
using KWSAdmin.Persistence.Interface.Dtos;
using KWSAdmin.Persistence.Interface.Interfaces;
using KWSAdmin.DALFactory;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;

namespace KWSAdmin.Application
{
    public class Client
    {
        public int id { get; private set; }
        public string FName { get; private set; }
        [Required] public string LName { get; private set; }
        public string Phone { get; private set; }
        [Required] public string EMail { get; private set; }
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

        public Client(int id, string fName, string lName, string phone, string eMail, string adres)
        {
            this.id = id;
            this.FName = fName;
            this.LName = lName;
            this.Phone = phone;
            this.EMail = eMail;
            this.Adres = adres;
        }


        public static IClientDal dal = ClientFactory.GetClientDal();

        public static Client GetByLName(string name, SqlConnection connection)
        {
            return new Client(dal.GetByLName(name, connection));
        }

        public static int AddClient(Client client, SqlConnection connection)
        {
            dal.Add(new ClientDto(0,client.FName,client.LName,client.Phone,client.EMail,client.Adres), connection);

            return GetByLName(client.LName,connection).id;
        }

        public static List<Client> GetAllClients(SqlConnection connection)
        {
            List<Client> clients = new List<Client>();
            foreach (var clientDto in dal.GetAllClients(connection))
            {
                clients.Add(new Client(clientDto));
            }

            return clients;
        }

        public override string ToString()
        {
            return id + ": " + LName + ", " + FName;
        }
    }
}
