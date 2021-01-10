using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using KWSAdmin.Application;
using KWSAdmin.Persistence.Interface.Dtos;


namespace AspView.Models
{
    public class OrderViewModel
    {
        public int  Id { get; set; }

        [Required] public Location Location { get; set; }

        public Client Client { get; set; }

        public Accu Accu { get; set; }

        public string Info { get; set; }

        public Account Creator { get; set; }

        public bool Done { get; set; }

        public List<Client> Clients { get; set; }

        public List<Accu> Accus { get; set; }

    }
}
