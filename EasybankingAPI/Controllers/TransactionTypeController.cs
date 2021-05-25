using Application.Core.CQRS.Commands.TransactionTypeCommand;
using Application.Core.CQRS.Queries.TransanctionTypes;
using Application.Core.DTOs.TransactionDTOs;
using Application.Core.Mappings;
using AutoMapper;
using Domain.Entities;
using MediatR;
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
	[ProducesResponseType(StatusCodes.Status400BadRequest)]
	public class TransactionTypeController : ControllerBase
	{
		private readonly IMediator _mediator;
		private readonly IMapper mapper;

		public TransactionTypeController(IMediator mediator, IMapper mapper)
		{
			_mediator = mediator;
			this.mapper = mapper;
		}
		[HttpGet("[action]")]
		[ProducesResponseType(200, Type = typeof(List<TransactionType>))]
		[ProducesResponseType(400)]
		public async Task<IActionResult> Index()
		{
			var response = await _mediator.Send(new GetAllTransactionTypeQuery());
			return Ok(response);

		}


		[HttpPost("[action]")]
		//[ProducesResponseType(201, Type = typeof(TransactionType))]
		[ProducesResponseType(StatusCodes.Status201Created)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		[ProducesDefaultResponseType]
		public async Task<IActionResult> Create([FromBody] AddTransactionTypeDTO transactionType)
		{
			var entity = mapper.Map<TransactionType>(transactionType);
			var response = await _mediator.Send(transactionType);
			return Ok(response);

		}
	}
}
