using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticket.Data.Enums;

namespace Ticket.Data.ViewModel
{
    public class TicketViewModel
    {
        public int ID { get; set; }
        [Required, MaxLength(250)]
        public string Title { get; set; }
        [MaxLength(1000)]
        public string Description { get; set; }
        public int Status { get; set; } = (int)StatusEnum.Ticket.New;
        public bool isDeleted { get; set; } = false;
        public int ConversationID { get; set; }
    }
}
