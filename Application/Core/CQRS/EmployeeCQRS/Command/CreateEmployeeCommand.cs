using Application.Common;
using Application.Core.DTOs.EmployeeDTO;
using Application.Core.HelperClass;
using Application.Core.Responses;
using Application.Identity;
using Application.Identyity.UserServices;
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
			private readonly IUserServices _userServices;
			private readonly UserManager<ApplicationUser> _userManager;

			public Handler(IMapper mapper, ApplicationDbContext context, UserManager<ApplicationUser> userManager, IUserServices userServices)
			{
				_mapper = mapper;
				_context = context;
				_userManager = userManager;
				_userServices = userServices;
			}

			public async Task<Response> Handle(Command request, CancellationToken cancellationToken)
			{
			
				var employeeeResponse = new EmployeeResponse();

				if(request.Employee.Id.Equals(Guid.Empty))
                {
					try
					{
						var employee = _mapper.Map<Employee>(request.Employee);
						employee.StaffCode = LogicHelper.GetStaffCode(_context, "Emp");
						await _context.Employees.AddAsync(employee);
						var user = new ApplicationUser
						{
							UserName = employee.StaffCode,
							Email = employee.Email,
							SecurityStamp = Guid.NewGuid().ToString(),
							Descriminator = UserDescriminator.Employee
						};
						var userResponse = await _userServices.CreateUserASync(user, employee.StaffCode, UserRole.Customer);
						if (userResponse.Status == ResponseStatus.Failed)
							return CoreResponse.OnFailureResponse(userResponse, userResponse.ResponseMessage);

						_context.SaveChanges();
						employeeeResponse.Name = employee.FullName;
						employeeeResponse.StaffCode = employee.StaffCode;

						return CoreResponse.OnSaveResponse(employeeeResponse);

					}
					catch (Exception exp)
					{

						return CoreResponse.OnFailureResponse(employeeeResponse, exp.Message);
					}
				}
                else
                {
                    try
					{
						var employee = _mapper.Map<Employee>(request.Employee);
						var entity = _context.Employees.Find(employee.Id);
						var iSConcurrency = employee.RowVersion != entity.RowVersion;
						if (iSConcurrency)
                        {

							return CoreResponse.GlobalResponse(employeeeResponse,"Another user has updated this record", "Failed", 404);
						}
						return CoreResponse.OnUpdateResponse(employeeeResponse);
					}
					catch (Exception exp)
					{

						return CoreResponse.OnFailureResponse(employeeeResponse, exp.Message);
					}
				}
				
				
			}
		}

	}
}
