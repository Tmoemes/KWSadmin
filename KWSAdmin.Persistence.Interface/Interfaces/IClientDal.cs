using System.Collections.Generic;
using System.Data.SqlTypes;
using KWSAdmin.Persistence.Interface.Dtos;
using System.Data.SqlClient;
using System.Threading.Tasks;


namespace KWSAdmin.Persistence.Interface.Interfaces
{
    public interface IClientDal
    {

        ClientDto GetById(int id, SqlConnection connection);

        ClientDto GetByLName(string name, SqlConnection connection);

        void Add(ClientDto order, SqlConnection connection);

        void UpdateClient(ClientDto order, SqlConnection connection);

        List<ClientDto> GetAllClients(SqlConnection connection);

    }
}
