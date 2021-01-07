namespace KWSAdmin.Persistence.Interface.Dtos
{
    public class OrderDto
    {

        public int Id { get; private set; }
        public int Clientid { get; private set; }
        public Location Location { get; private set; }
        public int Creatorid { get; private set; }
        public int Accuid { get; private set; }
        public string Info { get; private set; }

        public OrderDto(int id, int client, Location location, int creator, int accu, string info) 
        {
            this.Id = id;
            this.Clientid = client;
            this.Location = location;
            this.Creatorid = creator;
            this.Accuid =  accu;
            this.Info = info;
        }

    }
}
