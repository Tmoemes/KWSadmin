using System.ComponentModel.DataAnnotations;
using KWSAdmin.Application;
using KWSAdmin.Persistence.Interface.Dtos;


namespace AspView.Models
{
    public class OrderViewModel
    {
        [Required] public Location Location { get; set; }

        public string Client { get; set; }

        public string Accu { get; set; }

        public string Info { get; set; }

    }
}
