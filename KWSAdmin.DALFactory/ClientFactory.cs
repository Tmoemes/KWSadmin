using KWSAdmin.Persistence;

namespace KWSAdmin.DALFactory
{
    public class ClientFactory
        {
        public static ClientDal GetClientDal()
        {
            return new ClientDal();
        }
    }
}
