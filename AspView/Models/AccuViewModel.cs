using System.ComponentModel.DataAnnotations;
using KWSAdmin.Application;

namespace AspView.Models
{
    public class AccuViewModel
    {
        public int Id { get; set; }

        public int CreatorId { get; set; }

        public string CreatorName { get; set; }

        [Required]
        public string Name { get; set; }

        public string Specs { get; set; }

    }
}
