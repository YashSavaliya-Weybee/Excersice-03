using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Excersice_03.Models
{
    public class InvoiceModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Select Party")]
        public int? PartyId { get; set; }
        public string PartyName { get; set; }
        [Required(ErrorMessage = "Select Product")]
        public int? ProductId { get; set; }
        public string ProductName { get; set; }
        [Required(ErrorMessage = "Enter Rate")]
        public int? Rate { get; set; }
        [Required(ErrorMessage = "Enter Quantity")]
        public int? Quantity { get; set; }
        public int Total { get; set; }

    }
}
