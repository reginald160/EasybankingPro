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
	public class GetAllAcountQuery
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

					var records = await _db.Accounts.Where(x => x.Deleted.Equals(Universe.ISDeleted))
						.ProjectTo<AccountIndexDTO>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);

					return CoreResponse.OnSuccess(records);
				}
				catch (Exception exp)
				{
					return CoreResponse.NotFoundResponse(null, exp.Message);
				}

			}
		}
	}
}
