using Application.Common;
using Application.Core.HelperClass;
using Application.Core.Responses;
using Domain.Entities;
using Infrastructure.Persistence.DataAccess;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Domain.Enums;

namespace Application.Core.CQRS.TRansactionCQRS.Command
{
	public class FundTransaferCommand
	{
		public class Command : IRequest<Response>
		{
			public string SourceAcoountNumber { get; set; }
			public string DestinationAccountNumber { get; set; }
			public decimal Amount { get; set; }
		}

		public class Handler : RequestHandler<Command, Response>
		{
			private readonly ApplicationDbContext _db;
			private readonly ILogger<Handler> _logger;
			private readonly IMediator _mediator;

			public Handler(ApplicationDbContext db, ILogger<Handler> logger, IMediator mediator)
			{
				_db = db;
				_logger = logger;
				_mediator = mediator;
			}
			protected override Response Handle(Command request)
			{
				Response response = new Response();
				FundTransaferResponse transactionResponse = new FundTransaferResponse()
				{
					SourceAccount = request.SourceAcoountNumber,
					DestinationAccount = request.DestinationAccountNumber,
					Amount = request.Amount,
					TransactionType = "Transfer",
				};
				try
				{
					if (request.Amount < 100)
					{
						response.ResponseCode = ResponseCode.InvalidDepositAmount;
						response.ResponseMessage = ResponseMessage.InvalidDepositAmount;
						response.Data = null;
						return response;
					}

					var sourceAccount = _db.Accounts.Where(x => x.AccountNumber.Equals(request.SourceAcoountNumber)).FirstOrDefault();
					var destinationAccount = _db.Accounts.Where(x => x.AccountNumber.Equals(request.DestinationAccountNumber)).FirstOrDefault();

					if (sourceAccount == null)
						return CoreResponse.NotFoundResponse(request.SourceAcoountNumber, ResponseMessage.AccountNumberNotFound);

					if (destinationAccount == null)
						return CoreResponse.NotFoundResponse(request.DestinationAccountNumber, ResponseMessage.AccountNumberNotFound);


					var transactionType = _db.TransactionTypes.Where(x => x.Description == TransactionTypeDescription.Transfer).FirstOrDefault();
					decimal transactionCharge = transactionType.Charge;
					decimal totalAmount = request.Amount - transactionCharge;
					sourceAccount.CurrentAccountBalance =- totalAmount;
					destinationAccount.CurrentAccountBalance = +totalAmount;

					var transactionLog = new TransactionLog
					{
						TransactionTime = Universe.Now,
						TransactionAmount = request.Amount,	
						TransactionTypeId = transactionType.Id,
						NewBalance = sourceAccount.CurrentAccountBalance,
						SourceAccountNumber = sourceAccount.AccountNumber,
						TransactionDestinationAccount = destinationAccount.AccountNumber,
						AccountId = sourceAccount.Id,
						TransactionRefNumber = LogicHelper.GetTransactionId()

					};
					_db.Accounts.Update(sourceAccount);
					bool IsCompleted = _db.SaveChanges() > 0;
					
					if (IsCompleted)
					{
						transactionLog.Status = TransStatus.Successful;
						transactionLog.StatusMessage = "Successful Transanction";
						_db.Accounts.Update(destinationAccount);
						_db.Transactions.Add(transactionLog);
						_db.SaveChanges();
						transactionResponse.AccountBalance = sourceAccount.CurrentAccountBalance;
			
						return CoreResponse.GlobalResponse(transactionResponse, ResponseMessage.TransactionSuccessMessage,ResponseStatus.Success, ResponseCode.SuccesFullOperation);
					}

					transactionLog.Status = TransStatus.Failed;
					transactionLog.StatusMessage = "Failed Transanction";
					_db.Transactions.Add(transactionLog);
					_db.SaveChanges();

					return CoreResponse.GlobalResponse(transactionResponse, ResponseMessage.TransactionFailureMessage, ResponseStatus.Failed, ResponseCode.FailedOperation);

				}

				catch (Exception exp)
				{
					return CoreResponse.OnFailureResponse(transactionResponse, exp.Message);				
				}

			



			}
		}
	}
}
