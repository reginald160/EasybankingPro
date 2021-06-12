using Application.Common;
using Application.Core.DTOs.AccountDTOs;
using Application.Core.HelperClass;
using Application.Core.Responses;
using Application.Core.ViewModels.AccountViewModel;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Persistence.DataAccess;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core.CQRS.AccountCQRS.Command
{
	public class UpdateAccountCommand
	{
		public class Command : IRequest<Response>
		{
			public UpdateAccountDTO Account { get; set; }
		}

		public class Handler : RequestHandler<Command, Response>
		{
			private readonly ApplicationDbContext _db;
			private readonly IMapper _mapper;
			private Response response;
			AccountResponse accountResponse = new AccountResponse();

			public Handler(ApplicationDbContext db, IMapper mapper)
			{
				_db = db;
				_mapper = mapper;
			}

			protected override Response Handle(Command request)
			{
	
				try
				{
					var account = _db.Accounts.Where(x => x.AccountNumber == request.Account.AccountNumber).FirstOrDefault();
					var record = _mapper.Map<Account>(request.Account);
					_db.Accounts.Update(record);
					_db.SaveChanges();
					accountResponse.AccountNumber = record.FullName;
					accountResponse.AccountName = record.AccountNumber;
					
					return CoreResponse.OnUpdateResponse(accountResponse);
				}
				catch (Exception exp)
				{
					return CoreResponse.OnFailureResponse(accountResponse, exp.Message);
				}

			}
		}
	}
}
