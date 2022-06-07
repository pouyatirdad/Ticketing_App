
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Ticket.Data.Model
{
    public class ApplicationUser: IdentityUser
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }

        public ICollection<Conversation> conversations { get; set; }
    }
}
