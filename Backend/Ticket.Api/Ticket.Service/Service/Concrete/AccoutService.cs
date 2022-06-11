using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Ticket.Data.Model;
using Ticket.Data.ViewModel.Account;
using Ticket.Service.Service.Abstract;

namespace Ticket.Service.Service.Concrete
{
    public class AccoutService : IAccountService
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        public AccoutService(
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager
            )
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        public async string Login(LoginViewModel model)
        {
            var user = await userManager.FindByEmailAsync(model.Email);

            if (user == null)
                return "Some properties are not valid";

            var result = await userManager.CheckPasswordAsync(user, model.Password);

            if (result == false)
                return "Some properties are not valid";

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

            return tokenAsString;
        }


        public bool Register(RegisterViewModel model)
        {
            return false;
        }
    }
}
