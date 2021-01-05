using KWSAdmin.Persistence.Interface.Dtos;

namespace Interface
{
    public class OrderDto
    {

        public int id { get; private set; }
        public int clientid { get; private set; }
        public Location location { get; private set; }
        public int creatorid { get; private set; }
        public int accuid { get; private set; }
        public string info { get; private set; }

        public OrderDto(int id, int client, Location location, int creator, int accu, string info) 
        {
            this.id = id;
            this.clientid =  client;
            this.location = (Location) location;
            this.creatorid = creator;
            this.accuid =  accu;
            this.info = info;
        }

    }
}
