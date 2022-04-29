using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ticket.Data.ViewModel.Account;

namespace Ticket.Api.Controllers
{
    [ApiController]
    [EnableCors("MyPolicy")]
    [Route("[controller]")]
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;

        public AccountController(UserManager<IdentityUser> userManager)
        {
            this.userManager = userManager;
        }
        [HttpGet("test")]
        [Authorize]
        public List<string> test()
        {
            var model= new List<string>() {"hello","this is test" };
            return model;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {

            if (ModelState.IsValid)
            {

                var user = new IdentityUser()
                {
                    UserName = model.UserName,
                    Email = model.Email,
                    EmailConfirmed = true
                };

                var result = await userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                    return Ok(result);

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("error", error.Description);
                }

            }

            return BadRequest("Some properties are not valid"); // Status code: 400
        }
    }
}
