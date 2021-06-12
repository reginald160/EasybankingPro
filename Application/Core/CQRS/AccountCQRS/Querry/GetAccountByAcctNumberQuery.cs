using Application.Common;
using Application.Core.DTOs.AccountDTOs;
using Application.Core.DTOs.TransactionDTOs;
using Application.Core.HelperClass;
using Application.Core.Responses;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Entities;
using Infrastructure.Persistence.DataAccess;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Core.CQRS.TRansactionCQRS.Querry
{
	public class GetAccountByAcctNumberQuery
	{

		public class Query : IRequest<Response>
		{
			public string AccoutNumber { get; set; }
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
				try
				{
					var account = await _db.Accounts.Where(x => x.AccountNumber.Contains(request.AccoutNumber)).FirstOrDefaultAsync();
					var record = _mapper.Map<AccountIndexDTO>(account);
	
					return CoreResponse.OnSuccess(record);
				}
				catch (Exception exp)
				{
					
					return CoreResponse.NotFoundResponse(null, exp.Message);
				}

			}
		}
	}
}
