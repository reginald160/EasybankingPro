using Application.Common;
using Application.Core.DTOs.TransactionDTOs;
using Application.Core.HelperClass;
using AutoMapper;
using Infrastructure.Persistence.DataAccess;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Application.Core.CQRS.TRansactionCQRS.Query
{
	public class FindTransactionByDateQuery
	{
		public class Query : IRequest<Response>
		{
			public DateTime? TransactionFromDate { get; set; }
			public DateTime? TransactionToDate { get; set; }
		}

		public class Handler : RequestHandler<Query, Response>
		{
			private readonly ApplicationDbContext _db;
			private readonly IMapper _mapper;

			public Handler(ApplicationDbContext db, IMapper mapper)
			{
				_db = db;
				_mapper = mapper;
			}

			protected override Response Handle(Query query)
			{
				Response response = new Response();
				
				var entities = _db.Transactions.Where(x => x.Deleted.Equals(!Universe.ISDeleted))
					.Where(x => x.TransactionTime >= query.TransactionFromDate && x.TransactionTime <= query.TransactionToDate).ToList();	
				var transactions = _mapper.Map<IQueryable<TransactionDTO>>(entities);
				response.ResponseCode = ResponseCode.SuccesFullOperation;
				response.ResponseMessage = ResponseMessage.SuccesFullOperationMessage;
				response.Data = transactions;
			
				return response;

			}
		}
	}
}
