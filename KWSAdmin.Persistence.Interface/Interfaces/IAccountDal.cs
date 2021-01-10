using System.Data.SqlClient;
using KWSAdmin.Persistence.Interface.Dtos;



namespace KWSAdmin.Persistence.Interface.Interfaces
{
    public interface IAccountDal
    {
         AccountDto GetById(int id);

        void Add(AccountDto account);

        void UpdateUser(AccountDto account);

        AccountDto GetByName(string name);

        void DeleteAccount(int id);
    }
}
