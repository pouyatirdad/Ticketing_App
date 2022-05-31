using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticket.Data.ViewModel.Account
{
    public class UserViewModel
    {
        [Required, Display(Name = "نام کاربری")]
        public string UserName { get; set; }
        [Required, Display(Name = "ایمیل"), EmailAddress]
        public string Email { get; set; }
    }
}
