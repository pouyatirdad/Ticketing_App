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
            Assert.Equal("toekn",result.Result.ToString(),ignoreCase:true);
        }
        [Fact]
        public async Task Register_UserData_True()
        {
            var data = new RegisterViewModel()
            {
                UserName = "TestUser",
                Email = "Test@gmail.com",
                Password = "Test@123",
                RetypePassword="Test@123"
            };
            var result =(await accountController.Register(data) as ResponseViewModel) ;
            Assert.NotNull(result);
            Assert.Equal("true",result.IsSuccess.ToString().ToLower(),ignoreCase:true);
        }
    }
}
