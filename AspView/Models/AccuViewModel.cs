using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AspView.Models
{
    public class AccuViewModel
    {

        [Required] 
        public string Name { get; set; }

        public string Specs { get; set; }

    }
}
