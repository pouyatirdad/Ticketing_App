using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticket.Data.Model;
using Ticket.Service.Repository.Abstract;

namespace Ticket.Service.Service.Abstract
{
    public interface IConversationService:IBaseRepository<Conversation>
    {
    }
}
