using Application.Core.CQRS.AccountCQRS.Command;
using Application.Core.ViewModels.AccountViewModel;
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
    public class AccountController : ControllerBase
	{
        private readonly IMediator _mediator;
        private readonly IMapper mapper;

		public AccountController(IMediator mediator, IMapper mapper)
		{
			_mediator = mediator;
			this.mapper = mapper;
		}









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
                //var flight = _mapper.Map<Flight>(FlightDTO);
                var reponse = await _mediator.Send( new CreateAccountCommand.Command { Account = request});

                return Ok(reponse);
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
