using Ticket.Service.Repository.Abstract;


namespace Ticket.Service.Service.Abstract
{
    public interface ITicketService:IBaseRepository<Ticket.Data.Model.Ticket>
    {
        public void test();
    }
}
