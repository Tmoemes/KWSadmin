using System;
using System.Collections.Generic;
using System.Data;
using System.Net.Http;
using System.Text;
using KWSAdmin.Persistence.Interface.Dtos;
using KWSAdmin.Persistence.Interface.Interfaces;
using KWSAdmin.DALFactory;
using System.Data.SqlClient;
using System.Linq;

namespace KWSAdmin.Application
{
    public class Client
    {
        public int Id { get; private set; }
        public string FName { get; private set; }
        public string LName { get; private set; }
        public string Phone { get; private set; }
        public string EMail { get; private set; }
        public string Adres { get; private set; }

        public Client(ClientDto client)
        {
            this.Id = client.Id;
            this.FName = client.FName;
            this.LName = client.LName;
            this.Phone = client.Phone;
            this.EMail = client.EMail;
            this.Adres = client.Adres;

        }

        public Client(int id, string fName, string lName, string phone, string eMail, string adres)
        {
            this.Id = id;
            this.FName = fName;
            this.LName = lName;
            this.Phone = phone;
            this.EMail = eMail;
            this.Adres = adres;
        }


        public static IClientDal Dal = ClientFactory.GetClientDal();

        public static Client GetByLName(string name, SqlConnection connection)
        {
            return new Client(Dal.GetByLName(name, connection));
        }

        public static int AddClient(Client client, SqlConnection connection)
        {
            Dal.Add(new ClientDto(0,client.FName,client.LName,client.Phone,client.EMail,client.Adres), connection);

            return GetByLName(client.LName,connection).Id;
        }

        public static List<Client> GetAllClients(SqlConnection connection)
        {
            return Dal.GetAllClients(connection).Select(clientDto => new Client(clientDto)).ToList();
        }

        public override string ToString()
        {
            return Id + ": " + LName + ", " + FName;
        }
    }
}
