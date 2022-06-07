using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticket.Data.Enums;

namespace Ticket.Data.ViewModel
{
    public class ConversationViewModel
    {
        public int ID { get; set; }
        [Required, MaxLength(200)]
        public string UserName { get; set; }
        public string Title { get; set; }
        public int Status { get; set; } = (int)StatusEnum.Conversation.New;
        public bool IsDeleted { get; set; } = false;
    }
}
