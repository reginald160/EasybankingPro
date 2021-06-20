using Application.Common;
using Application.Core.CQRS.AccountCQRS.Command;
using Application.Core.CQRS.TRansactionCQRS.Command;
using Application.Core.CQRS.TRansactionCQRS.Querry;
using Application.Core.CQRS.TRansactionCQRS.Query;
using Application.Core.DTOs.TransactionDTOs;
using Application.Core.HelperClass;
using Application.Core.ViewModels.AccountViewModel;
using Application.Settings;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
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
		private AccountSettings _settings;
		private static string BankSettlementAccount;

		public TransactionController(IMediator mediator, IMapper mapper, IOptions<AccountSettings> settings)
		{
			_mediator = mediator;
			_mapper = mapper;
			BankSettlementAccount = _settings.BankSettlementAccount;
		}

		/// <summary>
		/// This is the method that returns the list of active flight
		/// </summary>
		/// <returns></returns>
		[HttpGet("[action]")]
		[ProducesResponseType(200, Type = typeof(ICollection<TransactionDTO>))]
		[ProducesResponseType(400)]
		public IActionResult GetTrnasactionByDate(DateTime dateFrom, DateTime dateTo)
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
		public async Task<IActionResult> GetAllTransactionType()
		{
			var request = await _mediator.Send(new AllTransactionType.Query());
			return request.Status.Equals(ResponseStatus.Success) ? Ok(request) : NotFound(request);
			
		}

		[HttpPost("[action]")]
		[ProducesResponseType(201, Type = typeof(TransactionDTO))]
		[ProducesResponseType(StatusCodes.Status201Created)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		[ProducesDefaultResponseType]
		public async Task<IActionResult> AccountOpening([FromBody] CreateAccountDTO request)
		{
			if (ModelState.IsValid)
			{
				var model = _mapper.Map<Account>(request);
				var result = await _mediator.Send(new CreateAccountCommand.Command { Account = request });

				return Ok(result);
			}
			return BadRequest(ModelState);
		}

		[HttpPost("[action]")]
		[ProducesResponseType(201, Type = typeof(DepositWithdrawalDTO))]
		[ProducesResponseType(StatusCodes.Status201Created)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		[ProducesDefaultResponseType]
		public async Task<IActionResult> Deposit([FromBody] DepositWithdrawalDTO request)
		{
			if (ModelState.IsValid)
			{
				var result = await _mediator.Send(new DepositCommand.Command {
					AccountNumber = request.AccountNumber, 
					Amount = request.Amount
				});

				return Ok(result);
			}
			return BadRequest(ModelState);
		}

		[HttpPost("[action]")]
		[ProducesResponseType(201, Type = typeof(DepositWithdrawalDTO))]
		[ProducesResponseType(StatusCodes.Status201Created)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		[ProducesDefaultResponseType]
		public async Task<IActionResult> Withdrawal([FromBody] DepositWithdrawalDTO request)
		{
			if (ModelState.IsValid)
			{
				var result = await _mediator.Send(new WithdrawalCommand.Command
				{
					AccountNumber = request.AccountNumber,
					Amount = request.Amount
				});

				return Ok(result);
			}
			return BadRequest(ModelState);
		}

		[HttpPost("[action]")]
		[ProducesResponseType(201, Type = typeof(FundTransfarDTO))]
		[ProducesResponseType(StatusCodes.Status201Created)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		[ProducesDefaultResponseType]
		public async Task<IActionResult> CashTransafer([FromBody] FundTransfarDTO request)
		{
			if (ModelState.IsValid)
			{
				var result = await _mediator.Send(new FundTransaferCommand.Command
				{
					DestinationAccountNumber = request.DestinationAccount,
					SourceAcoountNumber = request.SourceAccount,
					Amount = request.Amount
				});

				return Ok(result);
			}
			return BadRequest(ModelState);
		}

		

	}
}
