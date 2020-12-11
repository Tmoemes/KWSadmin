using Interface;
using KWSAdmin.Persistence.Interface.Dtos;

namespace KWSAdmin.Persistence.Interface.Interfaces
{
    public interface IUserDal
    {
        UserDto GetById(int id);

        void Add(UserDto user);

        void UpdateUser(UserDto user);

        UserDto GetByName(string name);
    }
}
