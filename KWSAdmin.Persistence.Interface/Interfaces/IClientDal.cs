using Interface;
using KWSAdmin.Persistence.Interface.Dtos;


namespace KWSAdmin.Persistence.Interface.Interfaces
{
    public interface IClientDal
    {

        ClientDto GetById(int id);

        ClientDto GetByLName(string name);

        void Add(ClientDto order);

        void UpdateClient(ClientDto order);

        
    }
}
