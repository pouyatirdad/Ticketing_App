using System.Collections.Generic;
using System.Linq;
using Ticket.Data.Context;
using Ticket.Service.Repository;

namespace Ticket.Service.Service.Concrete
{
    public class TicketService:BaseRepository<Ticket.Data.Model.Ticket>,ITicketService
    {
        private readonly MyDbContext context;
        public TicketService(MyDbContext context):base(context)
        {
            this.context = context;
        }

        public IEnumerable<Data.Model.Ticket> getAllWithStatus(int id)
        {
            var model = context.Tickets.Where(x => x.Status == id);
            return model;
        }
    }
}
