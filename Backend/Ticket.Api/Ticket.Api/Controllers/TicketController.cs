using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ticket.Service.Service;

namespace Ticket.Api.Controllers
{
    [ApiController]
    [EnableCors("MyPolicy")]
    [Route("[controller]")]
    public class TicketController : Controller
    {
        private readonly ITicketService ticketService;
        public TicketController(ITicketService ticketService)
        {
            this.ticketService = ticketService;
        }

        [HttpGet]
        public IEnumerable<Ticket.Data.Model.Ticket> Get()
        {
            return ticketService.GetAll();
        }
        [HttpGet("Get/{id:int}")]
        public Ticket.Data.Model.Ticket Get(int id)
        {
            var findedReslut = ticketService.GetById(id);
            return findedReslut;
        }
        [HttpGet("GetByConversation/{id:int}")]
        public IEnumerable<Ticket.Data.Model.Ticket> GetByConversationID(int id)
        {
            var findedReslut = ticketService.getWithConversationID(id);
            return findedReslut;
        }
        [HttpPost("Create")]
        public bool Create(Ticket.Data.Model.Ticket model)
        {
            return ticketService.Create(model);
        }
        [HttpPost("Edit")]
        public bool Edit(Ticket.Data.Model.Ticket model)
        {
            return ticketService.Edit(model);
        }
        [HttpPost("Delete")]
        public bool Delete(int id)
        {
            return ticketService.Delete(id);
        }
    }
}
