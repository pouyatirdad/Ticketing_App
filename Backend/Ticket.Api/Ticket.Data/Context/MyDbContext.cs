using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Ticket.Data.Model;

namespace Ticket.Data.Context
{
    public class MyDbContext : IdentityDbContext
    {
        public MyDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Ticket.Data.Model.Ticket> Tickets { get; set; }
        public DbSet<Conversation> Conversations { get; set; }
    }
}
