
using System.Collections.Generic;
using Ticket.Service.Repository;
using Ticket.Service.Repository.Abstract;

namespace Ticket.Service.Service
{
    public interface ITicketService:IBaseRepository<Ticket.Data.Model.Ticket>
    {
        public IEnumerable<Ticket.Data.Model.Ticket> getAllWithStatus(int id);
        public IEnumerable<Ticket.Data.Model.Ticket> getWithConversationID(int id);
    }
}
