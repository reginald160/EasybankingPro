using Application.Core.DTOs.IdentityUserDTO;
using Application.Core.HelperClass;
using Application.Core.Notification;
using Application.Identyity.UserServices;
using AutoMapper.Configuration;
using Infrastructure.Persistence;
using Infrastructure.Persistence.DataAccess;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasybankingAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[ProducesResponseType(StatusCodes.Status400BadRequest)]
	public class IdentityUserController : ControllerBase
	{
		private readonly IUserServices _userServices;
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly SignInManager<ApplicationUser> _signInManager;
		private readonly ApplicationDbContext _db;
		private readonly RoleManager<IdentityRole> _roleManager;
		private readonly IMessageNotification _message;


		public IdentityUserController(IUserServices userServices, UserManager<ApplicationUser> userManager,
			SignInManager<ApplicationUser> signInManager, ApplicationDbContext db, RoleManager<IdentityRole> roleManager, IMessageNotification message)
		{
			_userServices = userServices;
			_userManager = userManager;
			_signInManager = signInManager;
			_db = db;
			_roleManager = roleManager;
			_message = message;
		}

		[Route("identity")]
		[Authorize]
		[HttpGet]
		public IActionResult Get()
		{
			return new JsonResult(from c in User.Claims select new { c.Type, c.Value });
		}


		[Authorize]
		[HttpPost("[action]")]
		public string Index()
		{
			return "Secret message from  API1";
		}




		[HttpPost("[action]")]
		[ProducesResponseType(201, Type = typeof(LoginDTO))]
		[ProducesResponseType(StatusCodes.Status201Created)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		[ProducesDefaultResponseType]
		public async Task<IActionResult> Login([FromBody] LoginDTO login)
		{
			if (ModelState.IsValid)
			{
				//_message.SendEmail("ozougwuIfeanyi160@gmail.com", "Testiong from EasyBanking Pro", "That is very nice");
				var response = await _userServices.LoginAsync(login);

				return response.Status.Equals(ResponseStatus.Success) ? Ok(response) : Unauthorized();
			}
			return BadRequest(ModelState);
		}

		[HttpPost("[action]")]
		//[ProducesResponseType(201, Type = typeof(LoginDTO))]
		[ProducesResponseType(StatusCodes.Status201Created)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		[ProducesDefaultResponseType]
		public IActionResult SendSMS()
		{			
			var response = 	_message.SendSMS("08037620380", "FirstTwillo message");
			return Ok(response.Data);
		}


	}
}
