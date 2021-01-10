using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using KWSAdmin.Application;
using KWSAdmin.Persistence.Interface.Dtos;


namespace AspView.Models
{
    public class OrderViewModel
    {
        [Required] public Location Location { get; set; }

        public int ClientId { get; set; }

        public int AccuId { get; set; }

        public string Info { get; set; }

        public List<Client> Clients { get; set; }

        public List<Accu> Accus { get; set; }


    }
}
