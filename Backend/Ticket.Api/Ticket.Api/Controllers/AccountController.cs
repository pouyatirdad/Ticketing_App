using Microsoft.AspNetCore.Mvc;

namespace Ticket.Api.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel)
        {
            return View();
        }
    }
}
