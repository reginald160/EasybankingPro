using Application.Common;
using Application.Core.DTOs.TransactionDTOs;
using Application.Core.HelperClass;
using Application.Core.Responses;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Persistence.DataAccess;
using MediatR;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

		public class Handler : IRequestHandler<Command, Response>
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

		
			public async Task<Response> Handle(Command request, CancellationToken cancellationToken)
			{
				try
				{
					var transaction = _mapper.Map<TransactionLog>(request.Transaction);
					await _db.Transactions.AddAsync(transaction);
					_db.SaveChanges();
					return CoreResponse.GlobalResponse(transaction, "The transaction was successful", ResponseStatus.Success, ResponseCode.TransactionSuccess);
				}
				catch (Exception exp)
				{
					return CoreResponse.GlobalResponse(null, exp.Message, ResponseStatus.Failed, ResponseCode.TransactionFailure);

				}
			}
		}
	}
}
