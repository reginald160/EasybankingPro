using Application.Core.CQRS.EmployeeCQRS.Command;
using Application.Core.CQRS.EmployeeCQRS.Query;
using Application.Core.DTOs.EmployeeDTO;
using Application.Identity;
using MediatR;
using Microsoft.AspNetCore.Authorization;
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
	public class EmployeeController : ControllerBase
	{
		private readonly IMediator _mediator;

		public EmployeeController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpGet("[action]")]
		[ProducesResponseType(204)]
		[ProducesResponseType(201, Type = typeof(IEnumerable<GetAllEmployeeDTO>))]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		[ProducesDefaultResponseType]
		//[Authorize]
		public async Task<IActionResult> GetAllEmployee(CancellationToken token)
		{
			var request = await _mediator.Send(new GetAllEmployeeCommand.Query());
			return Ok(request);

		}

		[HttpGet("[action]")]
		[ProducesResponseType(204)]
		[ProducesResponseType(201, Type = typeof(GetAllEmployeeDTO))]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		[ProducesDefaultResponseType]
		//[Authorize]
		public async Task<IActionResult> GetEmployeeById(Guid id, CancellationToken token)
		{
			var request = await _mediator.Send(new GetEmployeeByIDQuery.Query { Id = id });
			return Ok(request);

		}

		[HttpPost("[action]")]
		[ProducesResponseType(201, Type = typeof(CreateEmployeeDTO))]
		[ProducesResponseType(StatusCodes.Status201Created)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		[ProducesDefaultResponseType]
		[Authorize(Roles = UserRole.SuperAdmin)]
		public async Task<IActionResult> CreateEmployee([FromBody] CreateEmployeeDTO request)
		{
			if (ModelState.IsValid)
			{
				var result = await _mediator.Send(new CreateEmployeeCommand.Command { Employee = request });
				return Ok(result);
			}
			return BadRequest(ModelState);
		}


		[HttpDelete("[action]")]
		[ProducesResponseType(204)]
		[ProducesResponseType(201, Type = typeof(GetAllEmployeeDTO))]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		[ProducesDefaultResponseType]
		//[Authorize]
		public async Task<IActionResult> DeleteEmployee(Guid id, CancellationToken token)
		{
			var request = await _mediator.Send(new DeleteEmployeeCommand.Query { Id = id });
			return Ok(request);

		}

	}
}
