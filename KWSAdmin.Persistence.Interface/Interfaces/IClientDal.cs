using Interface;
using KWSAdmin.Persistence.Interface.Dtos;

namespace KWSAdmin.Persistence.Interface.Interfaces
{
    public interface IClientDal
    {
        ClientDto GetById(int id);

        void Add(ClientDto order);

        void updateclient(ClientDto order);
    }
}
