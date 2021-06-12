using Application.Common;
using Application.Core.DTOs.TransactionTypeDTOs;
using Application.Core.HelperClass;
using Application.Core.Responses;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Infrastructure.Persistence.DataAccess;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Core.CQRS.TRansactionCQRS.Query
{
	public class AllTransactionType
	{
		public class Query : IRequest<Response>
		{

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
					var records = await _db.TransactionTypes.Where(x => x.Deleted.Equals(!Universe.ISDeleted))
						.ProjectTo<TransactionTypeDTO>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);
					response.ResponseCode = ResponseCode.SuccesFullOperation;
					response.ResponseMessage = ResponseMessage.SuccesFullOperationMessage;
					response.Status = ResponseStatus.Success;
					response.Data = records;
					return response;
				}
				catch (Exception exp)
				{
					response.ResponseCode = ResponseCode.FailedOperation;
					response.ResponseMessage = exp.Message;
					response.Status = ResponseStatus.Failed;
					response.Data = null;
					return response;
				}

			}
		}
	}
}
