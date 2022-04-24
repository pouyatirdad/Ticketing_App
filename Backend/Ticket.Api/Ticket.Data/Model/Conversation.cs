using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticket.Data.Model
{
    public class Conversation
    {
        [Key]
        public int ID { get; set; }
        [Required,MaxLength(200)]
        public string Title { get; set; }
        public bool Status{ get; set; }
        public bool IsDeleted { get; set; } = false;

        public ICollection<Ticket> Tickets { get; set; }

    }
}
