using System.Data.SqlClient;
using KWSAdmin.Persistence.Interface.Dtos;



namespace KWSAdmin.Persistence.Interface.Interfaces
{
    public interface IAccountDal
    {
         AccountDto GetById(int id, SqlConnection connection);

        void Add(AccountDto account, SqlConnection connection);

        void UpdateUser(AccountDto account, SqlConnection connection);

        AccountDto GetByName(string name, SqlConnection connection);

        void DeleteAccount(int id, SqlConnection connection);
    }
}
