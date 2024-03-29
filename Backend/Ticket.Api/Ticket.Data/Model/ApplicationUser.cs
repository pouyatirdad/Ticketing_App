﻿
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Ticket.Data.Model
{
    public class ApplicationUser: IdentityUser
    {
        public string Name { get; set; }
        public string Family { get; set; }
        public bool IsPublic { get; set; } = true;

        public ICollection<Conversation> conversations { get; set; }
    }
}
