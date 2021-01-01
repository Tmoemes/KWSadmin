using System.ComponentModel.DataAnnotations;


namespace AspView.Models
{
    public class CientViewModel
    {
        public string FName { get; set; }

        [Required]
        public string LName { get; set; }

        [Required]
        public string Phone { get; set; }
        
        public string EMail { get; set; }
        [Required]
        public string Adres { get; set; }
    }
}
