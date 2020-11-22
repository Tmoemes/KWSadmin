using KWSAdmin.Persistence.Interface.Dtos;

namespace Interface
{
    public class OrderDto
    {
        public int id { get; private set; }
        public ClientDto client { get; private set; }
        public Location location { get; private set; }
        public UserDto creator { get; private set; }
        public AccuDto accu { get; private set; }

        public OrderDto(int id, ClientDto client, Location location, UserDto creator, AccuDto accu) 
        {
            this.id = id;
            this.client =  client;
            this.location = (Location) location;
            this.creator = creator;
            this.accu =  accu;
        }
    }
}
