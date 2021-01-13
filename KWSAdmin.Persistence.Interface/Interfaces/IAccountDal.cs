using KWSAdmin.Persistence.Interface.Dtos;



namespace KWSAdmin.Persistence.Interface.Interfaces
{
    public interface IAccountDal
    {
        AccountDto GetAccountById(int id);

        void AddAccount(AccountDto account);

        void UpdateUser(AccountDto account);

        AccountDto GetAccountByName(string name);

        void DeleteAccount(int id);
    }
}
