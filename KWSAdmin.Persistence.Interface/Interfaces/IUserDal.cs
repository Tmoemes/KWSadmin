using System.Data.SqlClient;
using Interface;
using KWSAdmin.Persistence.Interface.Dtos;



namespace KWSAdmin.Persistence.Interface.Interfaces
{
    public interface IUserDal
    {
         UserDto GetById(int id, SqlConnection connection);

        void Add(UserDto user, SqlConnection connection);

        void UpdateUser(UserDto user, SqlConnection connection);

        UserDto GetByName(string name, SqlConnection connection);
    }
}
