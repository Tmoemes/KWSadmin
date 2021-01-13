using System.ComponentModel.DataAnnotations;

namespace AspView.Models
{
    public class AccuViewModel
    {

        [Required]
        public string Name { get; set; }

        public string Specs { get; set; }

    }
}
