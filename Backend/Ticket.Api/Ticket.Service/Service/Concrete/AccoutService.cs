using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
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

        public async Task<ResponseViewModel> Login(LoginViewModel model)
        {
            var user = await userManager.FindByEmailAsync(model.Email);

            if (user == null)
            {
                return new ResponseViewModel()
                {
                    Message = "User Is Null",
                    IsSuccess = false
                };
            }

            var result = await userManager.CheckPasswordAsync(user, model.Password);

            if (result == false)
            {
                return new ResponseViewModel()
                {
                    Message = "Property Is Not Valid",
                    IsSuccess = false
                };
            }

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

            return new ResponseViewModel()
            {
                Message = tokenAsString,
                IsSuccess = true
            };
        }


        public ResponseViewModel Register(RegisterViewModel model)
        {
            return null;
        }
    }
}
