using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Excersice_03.Models
{
    public class ProductRateModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Select Product")]
        public int? ProductId { get; set; }
        public string ProductName { get; set; }
        [Required(ErrorMessage = "Enter Rate of Product")]
        public int? Rate { get; set; }
        [Required(ErrorMessage = "Choose Date")]

        public DateTime DateOfRate { get; set; }
    }
}
