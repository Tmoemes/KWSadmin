using System;

namespace KWSAdmin.Persistence.Interface.Dtos
{
    public class UserDto
    {
        public int id { get; private set; }
        public string UserName { get; private set; }
        public string PassWord { get; private set; }
        public DateTime RegisterDate { get; private set; }

        public UserDto()
        {

        }
    }
}
