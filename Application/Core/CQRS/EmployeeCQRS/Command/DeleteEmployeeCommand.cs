using Application.Common;
using Application.Core.HelperClass;
using Application.Core.Responses;
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
	public class DeleteEmployeeCommand
	{
		public class Query : IRequest<Response>
		{
			public Guid Id { get; set; }
		}
		public class Handler : IRequestHandler<Query, Response>
		{
			private readonly ApplicationDbContext _db;
			

			public Handler(ApplicationDbContext db)
			{
				_db = db;
			
			}

			public async Task<Response> Handle(Query request, CancellationToken cancellationToken)
			{

				Response response = new Response();
				EmployeeResponse employeeResponse = new EmployeeResponse();
				try
				{
					var record = _db.Employees.Where(x => x.Deleted.Equals(!Universe.ISDeleted) && x.Id.Equals(request.Id)).FirstOrDefault();
					record.Deleted = true;
					_db.Employees.Update(record);
					_db.SaveChanges();
					response.ResponseCode = ResponseCode.SuccesFullOperation;
					response.ResponseMessage = ResponseMessage.SuccesFullOperationMessage;
					employeeResponse.Name = record.FullName;
					employeeResponse.StaffCode = record.StaffCode;
					response.Data = employeeResponse;
					return response;
				}
				catch (Exception exp)
				{
					response.ResponseCode = ResponseCode.FailedOperation;
					response.ResponseMessage = exp.Message;
					response.Data = null;
					return response;
				}
			}
		}
	}
}
