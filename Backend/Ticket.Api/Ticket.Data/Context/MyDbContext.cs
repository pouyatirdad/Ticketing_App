using Microsoft.EntityFrameworkCore;


namespace Ticket.Data.Context
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions options) : base(options)
        { }

        public DbSet<Model.Ticket> Tickets { get; set; }
    }
}
