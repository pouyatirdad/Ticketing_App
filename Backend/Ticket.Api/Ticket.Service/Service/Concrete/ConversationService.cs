using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticket.Data.Context;
using Ticket.Data.Model;
using Ticket.Service.Repository.Concrete;
using Ticket.Service.Service.Abstract;

namespace Ticket.Service.Service.Concrete
{
    public class ConversationService:BaseRepository<Conversation>, IConversationService
    {
        private readonly MyDbContext context;
        public ConversationService(MyDbContext context):base(context)
        {
            this.context = context;
        }

    }
}
