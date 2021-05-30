using Application.Core.CQRS.AccountCQRS.Command;
using Application.Core.CQRS.TRansactionCQRS.Querry;
using Application.Core.CQRS.TRansactionCQRS.Query;
using Application.Core.DTOs.TransactionDTOs;
using Application.Core.ViewModels.AccountViewModel;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
	public class TransactionController : ControllerBase
	{
		private readonly IMediator _mediator;
		private readonly IMapper _mapper;

		public TransactionController(IMediator mediator, IMapper mapper)
		{
			_mediator = mediator;
			_mapper = mapper;
		}

		/// <summary>
		/// This is the method that returns the list of active flight
		/// </summary>
		/// <returns></returns>
		[HttpGet("[action]")]
		[ProducesResponseType(200, Type = typeof(ICollection<TransactionDTO>))]
		[ProducesResponseType(400)]
		public IActionResult TrnasactionByDate(DateTime dateFrom, DateTime dateTo)
		{
			var response = _mediator.Send(new FindTransactionByDateQuery.Query { 
				TransactionFromDate = dateFrom, TransactionToDate = dateTo });
			//var flights = mapper.Map<ICollection<TransactionDTO>>(entities);

			return Ok(response);
		}


		[HttpGet("[action]")]
		[ProducesResponseType(204)]
		[ProducesResponseType(201, Type = typeof(List<AddTransactionTypeDTO>))]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		[ProducesDefaultResponseType]
		//[Authorize]
		public async Task<IActionResult> GetTransactionType(CancellationToken token)
		{
			var list = new List<AddTransactionTypeDTO>();
			try
			{

				var request = await _mediator.Send(new AllTransactionType.Query());
				return Ok(request);
			}

			catch (Exception ex) when (ex is TaskCanceledException || ex is OperationCanceledException)
			{
				return Ok(list);
			}



		}



		[HttpPost("[action]")]
		[ProducesResponseType(201, Type = typeof(TransactionDTO))]
		[ProducesResponseType(StatusCodes.Status201Created)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		[ProducesDefaultResponseType]
		public async Task<IActionResult> Create([FromBody] CreateAccountDTO request)
		{
			if (ModelState.IsValid)
			{
				var model = _mapper.Map<Account>(request);
				var result = await _mediator.Send(new CreateAccountCommand.Command { Account = request });

				return Ok(result);
			}
			return BadRequest(ModelState);
		}



	}
}
