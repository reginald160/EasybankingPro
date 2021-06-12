using Application.Common;
using Application.Core.DTOs.EmployeeDTO;
using Application.Core.HelperClass;
using Application.Core.Responses;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Persistence;
using Infrastructure.Persistence.DataAccess;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static Domain.Enums;

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
			private readonly UserManager<ApplicationUser> _userManager;

			public Handler(IMapper mapper, ApplicationDbContext context, UserManager<ApplicationUser> userManager )
			{
				_mapper = mapper;
				_context = context;
				_userManager = userManager;
			}

			public async Task<Response> Handle(Command request, CancellationToken cancellationToken)
			{
				
				var employeeeResponse = new EmployeeResponse();

				try
				{					
					var employee = _mapper.Map<Employee>(request.Employee);
					employee.StaffCode = LogicHelper.GetStaffCode(_context, "Emp");
					await  _context.Employees.AddAsync(employee);
					var user = new ApplicationUser
					{
						UserName = employee.StaffCode,
						Email = employee.Email,
						Descriminator = UserDescriminator.Employee
					};
					await _userManager.CreateAsync(user, employee.StaffCode);
					_context.SaveChanges();
					employeeeResponse.Name = employee.FullName;
					employeeeResponse.StaffCode = employee.StaffCode;

					return CoreResponse.OnSaveResponse(employeeeResponse);

				}
				catch(Exception exp)
				{

					return CoreResponse.OnFailureResponse(employeeeResponse, exp.Message);
				}
				
			}
		}

	}
}
