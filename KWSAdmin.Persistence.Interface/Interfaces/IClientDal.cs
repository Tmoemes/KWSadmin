using System.Collections.Generic;
using System.Data.SqlTypes;
using KWSAdmin.Persistence.Interface.Dtos;
using System.Data.SqlClient;
using System.Threading.Tasks;


namespace KWSAdmin.Persistence.Interface.Interfaces
{
    public interface IClientDal
    {

        ClientDto GetById(int id);

        ClientDto GetByLName(string name);

        void Add(ClientDto order);

        void UpdateClient(ClientDto order);

        List<ClientDto> GetAllClients();

        void DeleteClient(int id);
    }
}
