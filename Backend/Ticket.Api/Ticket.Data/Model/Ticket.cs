using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticket.Data.Model
{
    public class Ticket
    {
        [Key]
        public int ID { get; set; }
        [Required, MaxLength(250)]
        public string Title { get; set; }
        [MaxLength(1000)]
        public string Description { get; set; }
        public int Status{ get; set; }
        public bool isDeleted { get; set; }

    }
}
