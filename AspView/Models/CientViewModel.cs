using System.ComponentModel.DataAnnotations;


namespace AspView.Models
{
    public class CientViewModel
    {
        public string FName { get; set; }

        [Required]
        public string LName { get; set; }

        public string Phone { get; set; }
        [Required]
        public string EMail { get; set; }
        [Required]
        public string Adres { get; set; }
    }
}
