using KWSAdmin.Application;
using KWSAdmin.Persistence.Interface.Dtos;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace AspView.Models
{
    public class OrderViewModel
    {
        public int Id { get; set; }

        [Required] public Location Location { get; set; }

        public int ClientId { get; set; }

        public int AccuId { get; set; }

        [MaxLength(800)]
        public string Info { get; set; }

        public bool Done { get; set; }

        public List<Client> Clients { get; set; }

        public List<Accu> Accus { get; set; }

    }
}
