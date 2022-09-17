using Excersice_03.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Excersice_03.Models
{
    public class AssignPartyModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Select Party")]
        public int? PartyId { get; set; }
        public string PartyName { get; set; }
        [Required(ErrorMessage = "Select Product")]
        public int? ProductId { get; set; }
        public string ProductName { get; set; }
    }
}