namespace KWSAdmin.Persistence.Interface.Dtos
{
    public class AccuDto
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public int Creatorid { get; private set; }
        public string Specs { get; private set; }

        public AccuDto(int id, string name, int creator, string specs)
        {
            this.Id = id;
            this.Name = name;
            this.Creatorid = creator;
            this.Specs = specs;
        }
        public AccuDto(string name, int creator, string specs)
        {
            this.Name = name;
            this.Creatorid = creator;
            this.Specs = specs;
        }
    }
}
