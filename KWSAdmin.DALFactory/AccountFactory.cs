using KWSAdmin.Persistence;
using KWSAdmin.Persistence.Interface.Interfaces;

namespace KWSAdmin.DALFactory
{
    public class AccountFactory
    {
        public static IAccountDal GetUserDal()
        {
            return new AccountDal();
        }
    }
}
