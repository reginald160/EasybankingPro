//using Application.Common;
//using Application.Core.DTOs.AccountDTOs;
//using Application.Core.DTOs.TransactionDTOs;
//using Application.Core.HelperClass;
//using AutoMapper;
//using AutoMapper.QueryableExtensions;
//using Domain.Entities;
//using Infrastructure.Persistence.DataAccess;
//using MediatR;
//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading;
//using System.Threading.Tasks;

//namespace Application.Core.CQRS.TRansactionCQRS.Querry
//{
//	public class AllTransactions
//	{

//		public class Query : IRequest<Response>
//		{
			
//		}

//		public class Handler : IRequestHandler<Query, Response>
//		{
//			private readonly ApplicationDbContext _db;
//			private readonly IMapper _mapper;

//			public Handler(ApplicationDbContext db, IMapper mapper)
//			{
//				_db = db;
//				_mapper = mapper;
//			}


//			public async Task<Response> Handle(Query request, CancellationToken cancellationToken)
//			{

//				Response response = new Response();
//				try
//				{

//					var records = await _db.TransactionTypes.Where(x => x.Deleted.Equals(!Universe.ISDeleted))
//						.ProjectTo<AccountIndexDTO>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);

//					response.ResponseCode = ResponseCode.SuccesFullOperation;
//					response.ResponseMessage = ResponseMessage.SuccesFullOperationMessage;
//					response.Data = records;
//					return response;
//				}
//				catch(Exception exp )
//				{
//					response.ResponseCode = ResponseCode.FailedOperation;
//					response.ResponseMessage = exp.Message;
//					response.Data = null;
//					return response;
//				}
				
//			}
//		}
//	}
//}
