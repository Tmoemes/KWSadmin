using KWSAdmin.Persistence.Interface.Dtos;
using System.Collections.Generic;


namespace KWSAdmin.Persistence.Interface.Interfaces
{
    public interface IClientDal
    {

        ClientDto GetClientById(int id);

        ClientDto GetClientByLName(string name);

        void AddClient(ClientDto order);

        void UpdateClient(ClientDto order);

        List<ClientDto> GetAllClients();

        void DeleteClient(int id);
    }
}
