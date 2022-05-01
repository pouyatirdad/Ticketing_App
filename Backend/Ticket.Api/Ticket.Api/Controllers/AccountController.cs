using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
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

        public AccountController(UserManager<IdentityUser> userManager)
        {
            this.userManager = userManager;
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

                var claims = new[]
                    {
                        new Claim(ClaimTypes.Email,model.Email),
                        new Claim(ClaimTypes.NameIdentifier,user.Id)
                    };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("this is mein custom Secret key for authentication"));

                var token = new JwtSecurityToken
                    (
                        claims: claims,
                        expires: System.DateTime.Now.AddDays(30),
                        signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
                    );

                string tokenAsString = new JwtSecurityTokenHandler().WriteToken(token);

                return Ok(tokenAsString);
            }

            return BadRequest("Some properties are not valid"); // Status code: 400
        }
    }
}
