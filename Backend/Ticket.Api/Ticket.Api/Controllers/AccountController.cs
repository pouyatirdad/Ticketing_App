using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Ticket.Data.Model;
using Ticket.Data.ViewModel.Account;
using Ticket.Service.Service.Abstract;

namespace Ticket.Api.Controllers
{
    [ApiController]
    [EnableCors("MyPolicy")]
    [Route("[controller]")]
    public class AccountController : Controller
    {
        private readonly IAccountService accountService;

        public AccountController
            (
            IAccountService accountService
            )
        {
            this.accountService = accountService;
        }

        [HttpPost("CreateRole")]
        [Authorize(Roles = "Programmer")]
        public async Task<bool> CreateRole(string roleName)
        {
            return await accountService.CreateRole(roleName);
        }

        [HttpPost("register")]
        public async Task<ResponseViewModel> Register(RegisterViewModel model,bool IsAdmin=false)
        {

            if (ModelState.IsValid)
            {
                var result= await accountService.Register(model, IsAdmin);
                return result;
            }

            return new ResponseViewModel()
            {
                Message="We Got Error",
                IsSuccess=false,
            };
        }
        [HttpPost("login")]
        public async Task<ResponseViewModel> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                return await accountService.Login(model);
            }

            return new ResponseViewModel(){
                IsSuccess=false,
                Message= "Some properties are not valid"
            };
        }
        [HttpGet("AllUser")]
        public List<UserViewModel> GetAllUser()
        {
            var users = accountService.GetAllUser();
            return users;
        }
    }
}
