using System.ComponentModel.DataAnnotations;


namespace AspView.Models
{
    public class ClientViewModel
    {
        public int id { get; set; }
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public string Phone { get; set; }
        [Required]
        public string EMail { get; set; }
        [Required]
        public string Adres { get; set; }
    }
}
