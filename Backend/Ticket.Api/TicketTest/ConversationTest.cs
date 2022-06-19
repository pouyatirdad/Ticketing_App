
using Moq;
using Ticket.Api.Controllers;
using Ticket.Data.Model;
using Ticket.Data.ViewModel;
using Ticket.Service.Service.Abstract;
using Xunit;

namespace TicketTest
{
    public class ConversationTest
    {
        private readonly Mock<IConversationService> service;
        private readonly ConversationController controller;
        public ConversationTest()
        {
            service = new Mock<IConversationService>();
            controller = new ConversationController(service.Object);
        }
        [Fact]
        public void Create_GiveData_ReturnTrue()
        {
            //arrange
            var serviceData = new Conversation()
            {
                FromUserId = 1,
                ToUserId = 2,
                ID = 3,
                IsDeleted = false,
                Status = 1,
                Title = "this is test"
            };
            var controllerData = new ConversationViewModel()
            {
                FromUserId = 1,
                ToUserId = 2,
                ID = 3,
                IsDeleted = false,
                Status = 1,
                Title = "this is test",
                UserName = "test"
            };
            bool serviceResult = true;
            service.Setup(x=>x.Create(serviceData)).Returns(serviceResult);
            //service.setup(x=>x.create(data),return true);
            // act
            var result = controller.Create(controllerData);
            //asert
            //service.Verify(x=> x.Create(serviceData),Times.Once);
            //service.verify(x=>x.create,Times.Once);
            //Assert.True(result);
            Assert.Equal(serviceResult, result);
        }
        [Fact]
        public void Get_GiveId_ReturnTrue()
        {
            var data = new Conversation()
            {
                FromUserId= 1,
                ID =1,
                IsDeleted=false,
                Status = 1,
                Title="test",
                ToUserId= 2
            };
            service.Setup(x=>x.GetById(1)).Returns(data);
            var result = controller.Get(1);
            Assert.Equal(data,result);
        }
    }
}
