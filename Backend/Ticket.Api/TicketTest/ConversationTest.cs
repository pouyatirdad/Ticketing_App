﻿
using Moq;
using Ticket.Api.Controllers;
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
            var data = new ConversationViewModel()
            {
                FromUserId = 1,
                ToUserId = 2,
                ID = 3,
                IsDeleted = false,
                Status = 1,
                Title = "this is test",
                UserName = "testing user name"
            };
            var result = (controller.Create(data));
            Assert.True(result);
        }
    }
}
