using Moq;
using System.Collections.Generic;
using System.Linq;
using Ticket.Api.Controllers;
using Ticket.Service.Service;
using Xunit;

namespace TicketTest
{
    public class TicketTest
    {
        private readonly TicketController ticketController;
        private readonly Mock<ITicketService> ticketService;
        public TicketTest()
        {
            ticketService = new Mock<ITicketService>();
            ticketController = new TicketController(ticketService.Object);
        }
        [Fact]
        public void GetALl_True()
        {
            var result = (ticketController.Get() as IEnumerable<Ticket.Data.Model.Ticket>);
            Assert.NotNull(result);

            //this is for test, call the service in controller
            //mockContext.Verify(x => x.SaveChanges(), Times.Once());
            //mockContext.Verify(x => x.SaveChanges(), Times.Exactly(1));

            //add result.count()
            Assert.Equal("3", result.Count().ToString(), ignoreCase: true);
        }
        [Fact]
        public void Create_CorrectData_ReturnTrue()
        {
            var ServiceData=new Ticket.Data.Model.Ticket()
            {
                ConversationID = 1,
                Description ="test",
                ID = 1,
                isDeleted = false,
                Status=1,
                Title="test",
            };

            var data = new Ticket.Data.ViewModel.TicketViewModel()
            {
                ConversationID = 1,
                Description = "test",
                ID = 1,
                isDeleted = false,
                Status = 1,
                Title = "test",
            };
            //ticketService.Setup(x=>x.Create(ServiceData),true);
            var result = ticketController.Create(data);
            ticketService.Verify(x => x.Create(ServiceData), Times.Once());

            Assert.True(result);
        }
        [Fact]
        public void GetById_GiveID_ReturnTrue()
        {
            int ID = 1;
            IList<Ticket.Data.Model.Ticket> ServiceResult = new List<Ticket.Data.Model.Ticket>();
            ServiceResult.Add(new Ticket.Data.Model.Ticket()
            {
                ConversationID = 1,
                ID = 1,
                Description = "test",
                isDeleted = false,
                Status = 1,
                Title = "teestt"
            });

            ticketService.Setup(x => x.getWithConversationID(ID)).Returns(ServiceResult);
            var Controllerresult = ticketController.GetByConversationID(ID);

            Assert.Equal(ServiceResult,Controllerresult);
        }
    }
}
