using Microsoft.EntityFrameworkCore;

namespace Ticket.Data.Context
{
    public class MyDbContext:DbContext
    {
        public MyDbContext(DbContextOptions options):base(options)
        {
                
        }
        public DbSet<Ticket.Data.Model.Ticket> Tickets { get; set; }
    }
}
