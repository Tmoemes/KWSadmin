using KWSAdmin.Persistence.Interface.Dtos;

namespace Interface
{
    public class OrderDto
    {

        public int id { get; private set; }
        public int clientid { get; private set; }
        public int locationid { get; private set; }
        public int creatorid { get; private set; }
        public int accuid { get; private set; }

        public OrderDto(int id, int client, int location, int creator, int accu) 
        {
            this.id = id;
            this.clientid = client;
            this.locationid = location;
            this.creatorid = creator;
            this.accuid = accu;
        }
    }
}
