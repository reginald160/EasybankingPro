using Application.Core.HelperClass;
using Domain.Entities.ChatModels;
using Infrastructure.Persistence.DataAccess;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasybankingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
	[Authorize]
    public class ChatController : ControllerBase
    {
		private readonly IHubContext<ChatHubs> _chat;
        public ChatController(IHubContext<ChatHubs> chat)
        {
            _chat = chat;
        }
        [HttpPost("[action]")]
		[ProducesResponseType(StatusCodes.Status201Created)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		[ProducesDefaultResponseType]
		//[Authorize(Roles = UserRole.SuperAdmin)]
		public IActionResult JoinGroupChat(string connectionId, string roomName)
		{
			if (ModelState.IsValid)
			{
				var result =  _chat.Groups.Add(connectionId, roomName);
				return Ok(result);
			}
			return BadRequest(ModelState);
		}

		[HttpPost("[action]")]
		[ProducesResponseType(StatusCodes.Status201Created)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		[ProducesDefaultResponseType]
		//[Authorize(Roles = UserRole.SuperAdmin)]
		public IActionResult LeaveGroupChat(string connectionId, string roomName)
		{
			if (ModelState.IsValid)
			{
				var result = _chat.Groups.Remove(connectionId, roomName);
				return Ok(result);
			}
			return BadRequest(ModelState);
		}

		[HttpPost("[action]")]
		[ProducesResponseType(StatusCodes.Status201Created)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		[ProducesDefaultResponseType]
		//[Authorize(Roles = UserRole.SuperAdmin)]
		public IActionResult SendMessage(Guid chatId, string text, string roomName, [FromServices] ApplicationDbContext _context)
		{
			if (ModelState.IsValid)
			{
				var message = new Message
				{
					Text = text,
					SenderName = _context.User.Identity.Name,
					TimeStamp = DateTime.Now,
					ChatId = chatId

				};
				var result = _chat.Clients.Group(roomName).OnConnectedAsync();
				return Ok(result);
			}
			return BadRequest(ModelState);
		}

	}
}
