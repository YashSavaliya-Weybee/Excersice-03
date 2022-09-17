using Microsoft.EntityFrameworkCore;

namespace Excersice_03.Data
{
    public class PartyProductContext : DbContext
    {
        public PartyProductContext(DbContextOptions<PartyProductContext> options) : base(options)
        {

        }

        public DbSet<Party> tblParty { get; set; }
        public DbSet<Product> tblProduct { get; set; }
        public DbSet<ProductRate> tblProductRate { get; set; }
        public DbSet<AssignParty> tblAssignParty { get; set; }
        public DbSet<Invoice> tblInvoice { get; set; }

    }
}
