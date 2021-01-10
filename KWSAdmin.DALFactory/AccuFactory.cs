using KWSAdmin.Persistence;
using KWSAdmin.Persistence.Interface.Interfaces;

namespace KWSAdmin.DALFactory
{
    public class AccuFactory
    {
        public static IAccuDal GetAccuDal()
        {
            return new AccuDal();
        }

    }
}
