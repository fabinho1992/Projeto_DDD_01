using AutoMapper;
using Domain.Interfaces;
using Etidades.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPIs.Models;

namespace WebAPIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMessage _message;

        public MessageController(IMessage message, IMapper mapper)
        {
            _message = message;
            _mapper = mapper;
        }


        [Authorize]
        [Produces("/application/json")]
        [HttpPost("/api/Add")]
        public async Task<List<Notifies>> Add(MessageViewModel message)
        {
            message.UserId = await RetornarIdUsuarioLogado();
            var messageMap = _mapper.Map<Message>(message);
            await _message.Add(messageMap);
            return messageMap.Notitycoes;
        }


        [Authorize]
        [Produces("/application/json")]
        [HttpPost("/api/Update")]
        public async Task<List<Notifies>> Update(MessageViewModel message)
        {
            var messageMap = _mapper.Map<Message>(message);
            await _message.Update(messageMap);
            return messageMap.Notitycoes;
        }

        [Authorize]
        [Produces("/application/json")]
        [HttpPost("/api/Delete")]
        public async Task<List<Notifies>> Delete(MessageViewModel message)
        {
            var messageMap = _mapper.Map<Message>(message);
            await _message.Delete(messageMap);
            return messageMap.Notitycoes;
        }


        [Authorize]
        [Produces("/application/json")]
        [HttpPost("/api/GetById")]
        public async Task<MessageViewModel> GetById(Message message)
        {
            message = await _message.GetById(message.Id);
            var messageMap = _mapper.Map<MessageViewModel>(message);
            return messageMap;
        }


        [Authorize]
        [Produces("/application/json")]
        [HttpPost("/api/List")]
        public async Task<List<MessageViewModel>> List()
        {
            var messages = await _message.GetAll();
            var messagesmap = _mapper.Map<List<MessageViewModel>>(messages);
            return messagesmap;     
        }







        private async Task<string> RetornarIdUsuarioLogado()
        {
            if (User != null)
            {
                var idUsuario = User.FindFirst("idUsuario");
                return idUsuario.Value;
            }

            return string.Empty;
        }
    }
}
