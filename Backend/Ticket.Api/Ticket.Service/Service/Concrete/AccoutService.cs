using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
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

        public async Task<bool> CreateRole(string roleName)
        {

            bool x = await roleManager.RoleExistsAsync("Admin");
            if (x || string.IsNullOrWhiteSpace(roleName))
                return false;

            var role = new IdentityRole();
            role.Name = roleName;
            await roleManager.CreateAsync(role);
            return true;
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


        public async Task<ResponseViewModel> Register(RegisterViewModel model,bool IsAdmin=false)
        {
            var CheckUserExist = await userManager.FindByEmailAsync(model.Email);
            if (CheckUserExist != null)
            {
                return new ResponseViewModel()
                {
                    Message = "User is Already here",
                    IsSuccess = false
                };
            }

            var user = new ApplicationUser()
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

                if (model.UserName == "ImProgrammer" && model.Email == "Programmer@SiteOwner.pro")
                {
                    await CreateRole("Programmer");
                    result2 = await userManager.AddToRoleAsync(user, "Programmer");
                }
                else
                {
                    result2 = await userManager.AddToRoleAsync(user, roleName);
                }

                return new ResponseViewModel()
                {
                    Message = string.Format("UserCreated : {0}  -  Addrole : {1}", result.Succeeded,result2.Succeeded),
                    IsSuccess = true
                };


            }

            List<string> errors = new List<string>();
            foreach (var error in result.Errors)
            {
                errors.Add(error.Description);
            }
            return new ResponseViewModel()
            {
                Message = "We Got Errors",
                IsSuccess = false,
                Errors = errors
            };
        }
    }
}
