using Application.Common;
using Application.Core.DTOs.EmployeeDTO;
using Application.Core.HelperClass;
using Application.Core.Responses;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Persistence.DataAccess;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Core.CQRS.EmployeeCQRS.Command
{
	public class CreateEmployeeCommand
	{
		public class Command : IRequest<Response>
		{
			public CreateEmployeeDTO Employee { get; set; }
		}
		public class Handler : IRequestHandler<Command, Response>
		{
			private readonly IMapper _mapper;
			private readonly ApplicationDbContext _context;

			public Handler(IMapper mapper, ApplicationDbContext context)
			{
				_mapper = mapper;
				_context = context;
			}

			public async Task<Response> Handle(Command request, CancellationToken cancellationToken)
			{
				var response = new Response();
				try
				{
					
					var employee = _mapper.Map<Employee>(request.Employee);
					employee.StaffCode = LogicHelper.GetStaffCode(_context, "Emp");
					await  _context.BaseProfiles.AddAsync(employee);
					_context.SaveChanges();
					response.ResponseCode = ResponseCode.SuccesFullOperation;
					response.ResponseMessage = ResponseMessage.SuccesFullOperationMessage;
					var employeeeResponse = new EmployeeResponse()
					{
						Name = employee.FullName,
						StaffCode = employee.StaffCode,
					};	
					response.Data = employeeeResponse;

				}
				catch(Exception exp)
				{
				
					response.ResponseCode = ResponseCode.FailedOperation;
					response.ResponseMessage = exp.Message;
					return response;
				}
				return response;
			}
		}

	}
}
