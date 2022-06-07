using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Ticket.Data.Enums;

namespace Ticket.Data.Model
{
    public class Conversation
    {
        [Key]
        public int ID { get; set; }
        [Required,MaxLength(200)]
        public string Title { get; set; }
        public int Status { get; set; } = (int)StatusEnum.Conversation.New;
        public bool IsDeleted { get; set; } = false;

        public ICollection<Ticket> Tickets { get; set; }
        public string ApplicationUserUserName { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

    }
}
