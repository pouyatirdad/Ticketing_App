using Ticket.Data.Context;
using Ticket.Service.Repository.Concrete;
using Ticket.Service.Service.Abstract;

namespace Ticket.Service.Service.Concrete
{
    public class TicketService:BaseRepository<Ticket.Data.Model.Ticket>,ITicketService
    {
        private readonly MyDbContext context;
        public TicketService(MyDbContext context):base(context)
        {
            this.context = context;
        }

        public void test()
        {
            throw new System.NotImplementedException();
        }
    }
}
