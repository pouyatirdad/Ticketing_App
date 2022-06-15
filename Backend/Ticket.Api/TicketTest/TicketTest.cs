using Moq;
using System.Collections.Generic;
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
            ticketService=new Mock<ITicketService>();
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
            Assert.Equal("", result,ignoreCase:true);
        }
    }
}
