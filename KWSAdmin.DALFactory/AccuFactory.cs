using KWSAdmin.Persistence;

namespace KWSAdmin.DALFactory
{
    public class AccuFactory
    {
        public static AccuDal GetAccuDal()
        {
            return new AccuDal();
        }

    }
}
