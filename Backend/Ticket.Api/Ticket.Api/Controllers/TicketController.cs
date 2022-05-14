using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ticket.Data.Enums;
using Ticket.Data.ViewModel;
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
        public bool Create(TicketViewModel model)
        {
            var newModel = new Ticket.Data.Model.Ticket()
            {
                Title = model.Title,
                Status = (int)StatusEnum.Ticket.New,
                Description= model.Description,
                isDeleted=false,
                ConversationID=model.ConversationID,
            };
            return ticketService.Create(newModel);
        }
        [HttpPost("Edit")]
        public bool Edit(TicketViewModel model)
        {
            var newModel = new Ticket.Data.Model.Ticket()
            {
                ID= model.ID,
                Title = model.Title,
                Status = (int)StatusEnum.Ticket.New,
                Description = model.Description,
                isDeleted = false,
                ConversationID = model.ConversationID,
            };
            return ticketService.Edit(newModel);
        }
        [HttpPost("Delete")]
        public bool Delete(int id)
        {
            return ticketService.Delete(id);
        }
    }
}
