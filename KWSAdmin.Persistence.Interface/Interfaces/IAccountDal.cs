using System.Data.SqlClient;
using KWSAdmin.Persistence.Interface.Dtos;



namespace KWSAdmin.Persistence.Interface.Interfaces
{
    public interface IAccountDal
    {
         AccountDto GetById(int id, SqlConnection connection);

        void Add(AccountDto user, SqlConnection connection);

        void UpdateUser(AccountDto user, SqlConnection connection);

        AccountDto GetByName(string name, SqlConnection connection);
    }
}
