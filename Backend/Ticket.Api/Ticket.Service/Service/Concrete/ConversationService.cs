using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticket.Data.Context;
using Ticket.Data.Enums;
using Ticket.Data.Model;
using Ticket.Data.ViewModel;
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

        public bool CreateConversation(ConversationViewModel model)
        {
            var username = model.UserName;
            if (username == null)
            {
                //username = User.Identity.Name;
            }
            if (model.FromUserId == 0)
            {
                //model.FromUserId = User.Identity.id;
            }
            var newModel = new Conversation()
            {
                ApplicationUserUserName = username,
                Title = model.Title,
                IsDeleted = false,
                Status = (int)StatusEnum.Conversation.New,
                ToUserId = model.ToUserId,
                FromUserId = model.FromUserId,
            };
            return Create(newModel);
        }
    }
}
