namespace KWSAdmin.Persistence.Interface.Dtos
{
    public class ClientDto
    {
        public int Id { get; private set; }
        public string FName { get; private set; }
        public string LName { get; private set; }
        public string Phone { get; private set; }
        public string EMail { get; private set; }
        public string Adres { get; private set; }

        public ClientDto(int id, string fname, string lname, string phone, string email, string adres)
        {
            this.Id = id;
            this.FName = fname;
            this.LName = lname;
            this.Phone = phone;
            this.EMail = email;
            this.Adres = adres;
        }
    }
}
