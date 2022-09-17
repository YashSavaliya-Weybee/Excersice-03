using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Excersice_03.Models
{
    public class PartyModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Enter Party Name")]
        public string PartyName { get; set; }
    }
}
