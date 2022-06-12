using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Threading.Tasks;
using Ticket.Api.Controllers;
using Ticket.Data.ViewModel.Account;
using Ticket.Service.Service.Abstract;
using Xunit;

namespace TicketTest
{
    public class AccountTest
    {
        private readonly AccountController accountController;
        private readonly Mock<IAccountService> accountServiceMock;

        public AccountTest()
        {
            accountServiceMock = new Mock<IAccountService>();
            accountController = new AccountController(accountServiceMock.Object);
        }
        [Fact]
        public void Login()
        {
            var data = new LoginViewModel()
            {
                Email = "test@gmail.com",
                Password = "Test@123"
            };
            var result = (accountController.Login(data) as Task<IActionResult>);
            Assert.NotNull(result);
            Assert.Equal("login",result.Result.ToString(),ignoreCase:true);
        }
    }
}
