using AutoMapper;
using Ticket.Data.Model;
using Ticket.Data.ViewModel;

namespace Ticket.Service.Helpers
{
    public class AppMapper:Profile
    {
        public AppMapper()
        {
            CreateMap<ConversationViewModel,Conversation>();
            CreateMap<Conversation,ConversationViewModel>();
            CreateMap<TicketViewModel, Data.Model.Ticket>();
        }
    }
}
