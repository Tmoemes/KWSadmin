using System.ComponentModel.DataAnnotations;
using KWSAdmin.Application;
using KWSAdmin.Persistence.Interface.Dtos;


namespace AspView.Models
{
    public class OrderViewModel
    {
        [Required] public Location Location { get; set; }

        public Client Client { get; set; }

        public Accu Accu { get; set; }

        public string Info { get; set; }

    }
}
