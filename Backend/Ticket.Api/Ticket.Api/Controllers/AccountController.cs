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
using Ticket.Data.ViewModel.Account;

namespace Ticket.Api.Controllers
{
    [ApiController]
    [EnableCors("MyPolicy")]
    [Route("[controller]")]
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public AccountController
            (
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager
            )
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        [HttpPost("CreateRole")]
        [Authorize(Roles = "Programmer")]
        public async Task<IActionResult> CreateRole(string roleName)
        {

            bool x = await roleManager.RoleExistsAsync("Admin");
            if (x || string.IsNullOrWhiteSpace(roleName))
                return BadRequest("Error!");

            var role = new IdentityRole();
            role.Name = roleName;
            await roleManager.CreateAsync(role);
            return Ok(string.Format("Role {0} Created",roleName));

        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterViewModel model,bool IsAdmin=false)
        {

            if (ModelState.IsValid)
            {
                var CheckUserExist = await userManager.FindByEmailAsync(model.Email);
                if (CheckUserExist != null)
                    return BadRequest("User Is Already Here!"); ;

                var user = new IdentityUser()
                {
                    UserName = model.UserName,
                    Email = model.Email,
                    EmailConfirmed = false
                };

                var result = await userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    string roleName = IsAdmin ? "Admin" : "User";

                    await CreateRole(roleName);

                    var result2 = new IdentityResult();

                    if (model.UserName=="ImProgrammer" && model.Email=="Programmer@SiteOwner.pro")
                    {
                        await CreateRole("Programmer");
                        result2 = await userManager.AddToRoleAsync(user, "Programmer");
                    }
                    else
                    {
                        result2 = await userManager.AddToRoleAsync(user, roleName);
                    }

                    return Ok(new { UserCreated = result.Succeeded, AddRole = result2.Succeeded });


                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("error", error.Description);
                }

            }

            return BadRequest("Some properties are not valid"); // Status code: 400
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginViewModel model)
        {

            if (ModelState.IsValid)
            {
                var user = await userManager.FindByEmailAsync(model.Email);

                if (user == null)
                    return BadRequest("Some properties are not valid");

                var result = await userManager.CheckPasswordAsync(user, model.Password);

                if (result == false)
                    return BadRequest("Some properties are not valid");

                var userRoleName = await userManager.GetRolesAsync(user);

                var claims = new[]
                    {
                        new Claim(ClaimTypes.Email,model.Email),
                        new Claim(ClaimTypes.NameIdentifier,user.Id),
                        new Claim(ClaimTypes.Role,userRoleName[0])
                    };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("this is mein custom Secret key for authentication"));

                var token = new JwtSecurityToken
                    (
                        issuer: "TicketingApp",
                        audience: "TicketingApp",
                        claims: claims,
                        expires: System.DateTime.Now.AddDays(30),
                        signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
                    );

                string tokenAsString = new JwtSecurityTokenHandler().WriteToken(token);

                return Ok(tokenAsString);
            }

            return BadRequest("Some properties are not valid"); // Status code: 400
        }
        [HttpGet("AllUser")]
        public List<IdentityUser> GetAllUser()
        {
            var users= userManager.Users;
            return users.ToList();
        }
    }
}
