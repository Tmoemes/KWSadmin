using KWSAdmin.Persistence;
using KWSAdmin.Persistence.Interface.Interfaces;

namespace KWSAdmin.DALFactory
{
    public class ClientFactory
        {
        public static IClientDal GetClientDal()
        {
            return new ClientDal();
        }
    }
}
