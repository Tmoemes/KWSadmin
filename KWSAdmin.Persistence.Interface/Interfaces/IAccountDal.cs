using KWSAdmin.Persistence.Interface.Dtos;



namespace KWSAdmin.Persistence.Interface.Interfaces
{
    public interface IAccountDal
    {
        AccountDto GetAccountById(int id);

        bool AddAccount(AccountDto account);

        bool UpdateUser(AccountDto account);

        AccountDto GetAccountByName(string name);

        bool DeleteAccount(int id);
    }
}
