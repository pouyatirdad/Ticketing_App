using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Ticket.Data.ViewModel.Account;

namespace Ticket.Api.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;

        public AccountController(UserManager<IdentityUser> userManager)
        {
            this.userManager = userManager;
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {

            if (ModelState.IsValid)
            {

                var user = new IdentityUser()
                {
                    UserName=model.UserName,
                    Email=model.Email,
                    EmailConfirmed=true
                };

                var result= await userManager.CreateAsync(user,model.Password);

                if (result.Succeeded)
                {

                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("error",error.Description);
                }

            }            

            return View();
        }
    }
}
