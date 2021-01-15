using KWSAdmin.Persistence.Interface.Dtos;
using System.Collections.Generic;


namespace KWSAdmin.Persistence.Interface.Interfaces
{
    public interface IClientDal
    {

        ClientDto GetClientById(int id);

        ClientDto GetClientByLName(string name);

        bool AddClient(ClientDto order);

        bool UpdateClient(ClientDto order);

        List<ClientDto> GetAllClients();

        bool DeleteClient(int id);
    }
}
