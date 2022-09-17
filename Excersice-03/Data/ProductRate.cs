using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Excersice_03.Data
{
    public class ProductRate
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Rate { get; set; }
        public DateTime DateOfRate { get; set; }
        public Product Product { get; set; }
    }
}
