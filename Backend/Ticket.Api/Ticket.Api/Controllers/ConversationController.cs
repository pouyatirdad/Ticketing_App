using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ticket.Data.Enums;
using Ticket.Data.Model;
using Ticket.Data.ViewModel;
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
        public bool Create(ConversationViewModel model)
        {
            var username = model.UserName;
            if (username==null)
            {
                username = User.Identity.Name;
            }
            var newModel = new Conversation()
            {
                ApplicationUserUserName= username,
                Title = model.Title,
                IsDeleted = false,
                Status = (int)StatusEnum.Conversation.New,
            };
            return conversationService.Create(newModel);
        }
        [HttpPost("Edit")]
        public bool Edit(ConversationViewModel model)
        {
            var newModel = new Conversation()
            {
                ID = model.ID,
                Title = model.Title,
                IsDeleted = model.IsDeleted,
                Status = model.Status,
                ApplicationUserUserName = model.UserName,
            };
            return conversationService.Edit(newModel);
        }
        [HttpPost("Delete")]
        public bool Delete(int id)
        {
            return conversationService.Delete(id);
        }
    }
}
