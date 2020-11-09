using Interface;
using KWSAdmin.Persistence.Interface.Dtos;

namespace KWSAdmin.Persistence.Interface.Interfaces
{
    public interface IUserDal
    {
        UserDto GetById(int id);

        void Add(UserDto order);

        void updatuser(UserDto order);
    }
}
