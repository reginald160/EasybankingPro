using Application.Common;
using Application.Core.DTOs.TransactionDTOs;
using AutoMapper;
using Infrastructure.Persistence.DataAccess;
using MediatR;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Application.Core.CQRS.TRansactionCQRS.Command
{
	public  class CreateTransactionCommad
	{

		public class Command : IRequest<Response>
		{
			public TransactionDTO Transaction  { get; set; }
		}

		public class Handler : RequestHandler<Command, Response>
		{
			private readonly ApplicationDbContext _db;
			private readonly IMapper _mapper;
			private readonly ILogger<Handler> _logger;
			private readonly AppSettings _appSettings;
			private static string _bankSettlement;

			public Handler(ApplicationDbContext db, IMapper mapper, ILogger<Handler> logger, IOptions<AppSettings> appSettings)
			{
				_db = db;
				_mapper = mapper;
				_logger = logger;
				_appSettings = appSettings.Value;
				_bankSettlement = _appSettings.BankSettlement;
			}

			protected override Response Handle(Command request)
			{
				Response response = new Response();
				var transaction = _mapper.Map<Transaction>(request.Transaction);
				//_db.Transactions.Add();
				bool reponseType = _db.SaveChanges() > 1;
				if(reponseType.Equals(true))
				{
					response.ResponseCode = 01;
					response.ResponseMessage = "The transaction was successfuly";
					response.Data = transaction;
					return response;
				}
				else
				{
					response.ResponseCode = 00;
					response.ResponseMessage = "Transaction failed";
					response.Data = null;
					return response;
				}
				
				
			}
		}
	}
}
