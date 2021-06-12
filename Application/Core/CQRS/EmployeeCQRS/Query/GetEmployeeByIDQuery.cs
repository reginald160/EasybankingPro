using Application.Common;
using Application.Core.DTOs.EmployeeDTO;
using Application.Core.HelperClass;
using Application.Core.Responses;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Infrastructure.Persistence.DataAccess;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Core.CQRS.EmployeeCQRS.Query
{
	public class GetEmployeeByIDQuery
	{
		public class Query : IRequest<Response>
		{
			public Guid Id { get; set; }
		}
		public class Handler : IRequestHandler<Query, Response>
		{
			private readonly ApplicationDbContext _db;
			private readonly IMapper _mapper;

			public Handler(ApplicationDbContext db, IMapper mapper)
			{
				_db = db;
				_mapper = mapper;
			}

			public async Task<Response> Handle(Query request, CancellationToken cancellationToken)
			{

				Response response = new Response();
				try
				{
					var records =  _db.Employees.Where(x => x.Deleted.Equals(!Universe.ISDeleted) && x.Id.Equals(request.Id))
						.ProjectTo<GetAllEmployeeDTO>(_mapper.ConfigurationProvider).FirstOrDefault();

					response.ResponseCode = ResponseCode.SuccesFullOperation;
					response.ResponseMessage = ResponseMessage.SuccesFullOperationMessage;
					response.Data = records;
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
