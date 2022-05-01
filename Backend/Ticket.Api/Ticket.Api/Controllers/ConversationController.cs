using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ticket.Data.Model;
using Ticket.Service.Service;
using Ticket.Service.Service.Abstract;

namespace Ticket.Api.Controllers
{
    [ApiController]
    [EnableCors("MyPolicy")]
    [Route("[controller]")]
    public class ConversationController : Controller
    {
        private readonly IConversationService conversationService;
        public ConversationController(IConversationService conversationService)
        {
            this.conversationService = conversationService;
        }

        [HttpGet("test")]
        [Authorize]
        public string test()
        {
            return "hi";
        }

        [HttpGet]
        public IEnumerable<Conversation> Get()
        {
            return conversationService.GetAll();
        }
        [HttpGet("Get/{id:int}")]
        public Conversation Get(int id)
        {
            var findedReslut = conversationService.GetById(id);
            return findedReslut;
        }
        [HttpPost("Create")]
        public bool Create(Conversation model)
        {
            return conversationService.Create(model);
        }
        [HttpPost("Edit")]
        public bool Edit(Conversation model)
        {
            return conversationService.Edit(model);
        }
        [HttpPost("Delete")]
        public bool Delete(int id)
        {
            return conversationService.Delete(id);
        }
    }
}
