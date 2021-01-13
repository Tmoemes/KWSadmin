using KWSAdmin.Application;
using KWSAdmin.Persistence.Interface.Dtos;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AspView.Models
{
    public class CreateOrderViewModel
    {
        public List<Client> Clients { get; set; }

        public List<Accu> Accus { get; set; }

        [Required] public Location Location { get; set; }

        public string Client { get; set; }

        public string Accu { get; set; }

        public string Info { get; set; }



    }
}
