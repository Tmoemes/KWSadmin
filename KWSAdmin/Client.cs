using KWSAdmin.DALFactory;
using KWSAdmin.Persistence.Interface.Dtos;
using KWSAdmin.Persistence.Interface.Interfaces;
using System.Collections.Generic;
using System.Data;
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

        public readonly IClientDal _clientDal = ClientFactory.GetClientDal();

        public Client GetClientByLName(string name)
        {
            return new Client(_clientDal.GetClientByLName(name));
        }

        public void AddClient(Client client)
        {
            _clientDal.AddClient(new ClientDto(client.FirstName, client.LastName, client.Phone, client.EMail, client.Adres));
        }

        public List<Client> GetAllClients()
        {
            return _clientDal.GetAllClients().Select(clientDto => new Client(clientDto)).ToList();
        }

        public Client GetClientById(int id)
        {
            return new Client(_clientDal.GetClientById(id));
        }

        public bool UpdateClient(Client client)
        {
            return _clientDal.UpdateClient(new ClientDto(client.Id, client.FirstName, client.LastName, client.Phone,
                client.EMail, client.Adres));
        }

    }
}
