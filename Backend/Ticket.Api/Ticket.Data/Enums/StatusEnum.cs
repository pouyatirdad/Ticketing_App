using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticket.Data.Enums
{
    public class StatusEnum
    {
        public enum Conversation
        {
            New=1,
            Seen=2,
            Answer=3,
            Close=4
        }
        public enum Ticket
        {
            New = 1,
            Seen = 2
        }
    }
}
