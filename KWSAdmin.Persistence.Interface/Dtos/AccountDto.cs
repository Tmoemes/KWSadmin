namespace KWSAdmin.Persistence.Interface.Dtos
{
    public class AccountDto
    {
        public int Id { get; private set; }
        public string Username { get; private set; }
        public string Password { get; private set; }
        public bool Admin { get; private set; }

        public AccountDto(int id, string username, string password, bool admin)
        {
            this.Id = id;
            this.Username = username;
            this.Password = password;
            this.Admin = admin;
        }
    }
}
