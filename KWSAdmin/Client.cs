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
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Phone { get; private set; }
        public string EMail { get; private set; }
        public string Adres { get; private set; }

        public Client(ClientDto client)
        {
            this.Id = client.Id;
            this.FirstName = client.FirstName;
            this.LastName = client.LastName;
            this.Phone = client.Phone;
            this.EMail = client.EMail;
            this.Adres = client.Adres;
        }

        public Client(int id, string firstName, string lastName, string phone, string eMail, string adres)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Phone = phone;
            this.EMail = eMail;
            this.Adres = adres;
        }

        //constructor for adding client without id
        public Client(string firstName, string lastName, string phone, string eMail, string adres)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Phone = phone;
            this.EMail = eMail;
            this.Adres = adres;
        }

        public Client()
        {
            
        }

        public IClientDal Dal = ClientFactory.GetClientDal();

        public Client GetByLName(string name, SqlConnection connection)
        {
            return new Client(Dal.GetByLName(name, connection));
        }

        public void AddClient(Client client, SqlConnection connection)
        {
            Dal.Add(new ClientDto(client.FirstName,client.LastName, client.Phone, client.EMail,client.Adres), connection);
        }

        public List<Client> GetAllClients(SqlConnection connection)
        {
            return Dal.GetAllClients(connection).Select(clientDto => new Client(clientDto)).ToList();
        }

        public override string ToString()
        {
            return Id + ": " + LastName + ", " + FirstName;
        }
    }
}
