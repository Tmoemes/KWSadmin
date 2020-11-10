using System;

namespace KWSAdmin.Persistence.Interface.Dtos
{
    public class UserDto
    {
        public int id { get; private set; }
        public string username { get; private set; }
        public string password { get; private set; }
        public DateTime registerDate { get; private set; }

        public UserDto()
        {

        }
    }
}
