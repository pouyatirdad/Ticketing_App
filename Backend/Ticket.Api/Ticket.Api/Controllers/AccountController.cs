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
        //private readonly UserManager<ApplicationUser> userManager;
        //private readonly RoleManager<IdentityRole> roleManager;
        private readonly IAccountService accountService;

        public AccountController
            (
            //UserManager<ApplicationUser> userManager,
            //RoleManager<IdentityRole> roleManager
            IAccountService accountService
            )
        {
            this.accountService = accountService;
        }

        [HttpPost("CreateRole")]
        [Authorize(Roles = "Programmer")]
        public async Task<IActionResult> CreateRole(string roleName)
        {

            //bool x = await roleManager.RoleExistsAsync("Admin");
            //if (x || string.IsNullOrWhiteSpace(roleName))
            //    return BadRequest("Error!");

            //var role = new IdentityRole();
            //role.Name = roleName;
            //await roleManager.CreateAsync(role);
            //return Ok(string.Format("Role {0} Created",roleName));
            return null;

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
        public async Task<IActionResult> Login(LoginViewModel model)
        {

            //if (ModelState.IsValid)
            //{
            //    var user = await userManager.FindByEmailAsync(model.Email);

            //    if (user == null)
            //        return BadRequest("Some properties are not valid");

            //    var result = await userManager.CheckPasswordAsync(user, model.Password);

            //    if (result == false)
            //        return BadRequest("Some properties are not valid");

            //    var userRoleName = await userManager.GetRolesAsync(user);

            //    var claims = new[]
            //        {
            //            new Claim(ClaimTypes.Email,model.Email),
            //            new Claim(ClaimTypes.NameIdentifier,user.Id),
            //            new Claim(ClaimTypes.Role,userRoleName[0])
            //        };

            //    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("this is mein custom Secret key for authentication"));

            //    var token = new JwtSecurityToken
            //        (
            //            issuer: "TicketingApp",
            //            audience: "TicketingApp",
            //            claims: claims,
            //            expires: System.DateTime.Now.AddDays(30),
            //            signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
            //        );

            //    string tokenAsString = new JwtSecurityTokenHandler().WriteToken(token);

            //    return Ok(tokenAsString);
            //}

            return BadRequest("Some properties are not valid"); // Status code: 400
        }
        [HttpGet("AllUser")]
        public List<UserViewModel> GetAllUser()
        {
            var users = accountService.GetAllUser();
            return users;
        }
    }
}
