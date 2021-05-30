using Application.Common;
using Application.Core.CQRS.AccountCQRS.Command;
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


		//[HttpGet("[action]")]
		//[ProducesResponseType(204)]
		//[ProducesResponseType(201, Type = typeof(List<AccountIndexDTO>))]
		//[ProducesResponseType(StatusCodes.Status404NotFound)]
		//[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		//[ProducesDefaultResponseType]
		////[Authorize]
		//public async Task<IActionResult> Index(CancellationToken token)
		//{
		//	var list = new List<AccountIndexDTO>();
		//	try
		//	{
				
		//		var request = await _mediator.Send(new GetAllTransactionType.Query());
		//		return Ok(request);
		//	}
		
		//	 catch (Exception ex) when (ex is TaskCanceledException || ex is OperationCanceledException)
		//	{
		//		return Ok(list);
		//	}			

		//}



		[HttpPost("[action]")]
		[ProducesResponseType(201, Type = typeof(CreateAccountDTO))]
		[ProducesResponseType(StatusCodes.Status201Created)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		[ProducesDefaultResponseType]
		public async Task<IActionResult> Create([FromBody] CreateAccountDTO request)
		{
			if (ModelState.IsValid)
			{
				try
				{
					//var entity = mapper.Map<Account>(request);
					var result = await _mediator.Send(new CreateAccountCommand.Command { Account = request });

					return Ok(result);
				}
				catch(Exception exp)
				{

					//logger.LogError($"AN ERROR OCCOURED....{exp.Message}");

					var response = new Response()
					{
						ResponseCode = ResponseCode.FailedOperation,
						ResponseMessage = exp.Message,
					};
					return Ok(response);
					
				}
			   
			   
			}
			return BadRequest(ModelState);
		}


		[HttpPatch("[action]")]
		[ProducesResponseType(204)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		[ProducesDefaultResponseType]
		//[Authorize]
		public async Task<IActionResult> Delete(Guid id)
		{
			//if (account == null || id != account.Id)
			//    return BadRequest(ModelState);
			if (ModelState.IsValid)
			{

				var request = _mediator.Send(new DeleteAccountCommand.Command { Id = id}); 

				//var flight = _mapper.Map<Flight>(FlightDTO);
				//var sucess = await _unitOfWork.flight.UpdateAsync(flight);
				//if (!sucess)
				//{
				//    ModelState.AddModelError("", Universe.Error500);
				//    return StatusCode(500, ModelState);
				//}
				return Ok(request);
			}
			return BadRequest(ModelState);

		}
	}
}
