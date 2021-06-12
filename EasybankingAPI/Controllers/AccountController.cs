using Application.Common;
using Application.Core.CQRS.AccountCQRS.Command;
using Application.Core.CQRS.EmployeeCQRS.Query;
using Application.Core.CQRS.TRansactionCQRS.Querry;
using Application.Core.DTOs.AccountDTOs;
using Application.Core.HelperClass;
using Application.Core.ViewModels.AccountViewModel;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EasybankingAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[ProducesResponseType(StatusCodes.Status400BadRequest)]
	public class AccountController : ControllerBase
	{
		private readonly IMediator _mediator;
		private readonly IMapper mapper;
		private readonly ILogger<AccountController> logger;

		public AccountController(IMediator mediator, IMapper mapper, ILogger<AccountController> logger)
		{
			_mediator = mediator;
			this.mapper = mapper;
			this.logger = logger;
		}
		[HttpGet("[action]")]
		[ProducesResponseType(204)]
		[ProducesResponseType(201, Type = typeof(AccountIndexDTO))]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		[ProducesDefaultResponseType]
		//[Authorize]
		public async Task<IActionResult> GetAllAcounts(CancellationToken token)
		{
			var response = await _mediator.Send(new GetAllAcountQuery.Query());
			return response.Status.Equals(Universe.SuccessStatus) ? Ok(response) : NotFound(response);

		}



		[HttpGet("[action]")]
		[ProducesResponseType(204)]
		[ProducesResponseType(201, Type = typeof(IEnumerable<AccountIndexDTO>))]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		[ProducesDefaultResponseType]
		//[Authorize]
		public async Task<IActionResult> GetAccountByAccountNumber(string accountNumber, CancellationToken token)
		{
			var response = await _mediator.Send(new GetAccountByAcctNumberQuery.Query { AccoutNumber = accountNumber });
			return response.Status.Equals(Universe.SuccessStatus) ? Ok(response) : NotFound(response);

		}


		[HttpPost("[action]")]
		[ProducesResponseType(201, Type = typeof(CreateAccountDTO))]
		[ProducesResponseType(StatusCodes.Status201Created)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		[ProducesDefaultResponseType]
		public async Task<IActionResult> CreateAccount([FromBody] CreateAccountDTO request)
		{
			if (ModelState.IsValid)
			{
				var result = await _mediator.Send(new CreateAccountCommand.Command { Account = request });
				return result.ResponseCode.Equals(200) ? Ok(result) : BadRequest(result);   
			}
			return BadRequest(ModelState);
		}

		[HttpPatch("[action]")]
		[ProducesResponseType(201, Type = typeof(UpdateAccountDTO))]
		[ProducesResponseType(StatusCodes.Status201Created)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		[ProducesDefaultResponseType]
		public async Task<IActionResult> UpdateAccount([FromBody] UpdateAccountDTO request)
		{
			if (ModelState.IsValid)
			{
				var result = await _mediator.Send(new UpdateAccountCommand.Command { Account = request });
				return result.ResponseCode.Equals(200) ? Ok(result) : BadRequest(result);
			}
			return BadRequest(ModelState);
		}


		[HttpDelete("[action]")]
		[ProducesResponseType(204)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		[ProducesDefaultResponseType]
		//[Authorize]
		public async Task<IActionResult> DeleteAccount(Guid id)
		{
			if (ModelState.IsValid)
			{

				var request = await _mediator.Send(new DeleteAccountCommand.Command { Id = id}); 
				return Ok(request);
			}
			return BadRequest(ModelState);

		}
	}
}
