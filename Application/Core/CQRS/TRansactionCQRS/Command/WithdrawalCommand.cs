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
using System.Transactions;
using static Domain.Enums;

namespace Application.Core.CQRS.TRansactionCQRS.Command
{
	public class WithdrawalCommand
	{
		public class Command : IRequest<Response>
		{
			public decimal Amount { get; set; }
			public string AccountNumber { get; set; }

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
				WithdrawalDepositRespponse transactionResponse = new WithdrawalDepositRespponse()
				{
					AccountNumber = request.AccountNumber,
					Amount = request.Amount,
					TransactionType = "Withdrawal"
				};

				try
				{
					if (request.Amount < 100)
						return CoreResponse.GlobalResponse(transactionResponse, ResponseMessage.InvalidDepositAmount, ResponseStatus.Failed, ResponseCode.InvalidWithdrawalAmount);

					var account = _db.Accounts.Where(x => x.AccountNumber.Equals(request.AccountNumber)).FirstOrDefault();

					if (account == null)
						return CoreResponse.NotFoundResponse(request.AccountNumber, ResponseMessage.AccountNumberNotFound);

					if (request.Amount < account.CurrentAccountBalance )
						return CoreResponse.GlobalResponse(request.AccountNumber, ResponseMessage.LowDebitAmountMessage, ResponseStatus.Failed, ResponseCode.LowDebitAmount);
					
					var transactionType = _db.TransactionTypes.Where(x => x.Description == TransactionTypeDescription.Withdrawal).FirstOrDefault();
					decimal transactionCharge = transactionType.Charge;
					decimal totalAmount = request.Amount - transactionCharge;
					account.CurrentAccountBalance =- totalAmount;

					var transactionLog = new TransactionLog
					{
						TransactionTime = Universe.Now,
						TransactionAmount = request.Amount,
						TransactionTypeId = transactionType.Id,
						NewBalance = account.CurrentAccountBalance,
						AccountId = account.Id,
						TransactionRefNumber = LogicHelper.GetTransactionId(),
					
					};
					_db.Accounts.Update(account);
					bool IsCompleted = _db.SaveChanges() > 0;
					
					if (IsCompleted)
					{
						
						transactionLog.Status = TransStatus.Successful;
						transactionLog.StatusMessage = "Successful Transanction";
						_db.Transactions.Add(transactionLog);
						_db.SaveChanges();
						transactionResponse.AccountBalance = account.CurrentAccountBalance;

						return CoreResponse.GlobalResponse(transactionResponse, ResponseMessage.TransactionSuccessMessage, ResponseStatus.Success, ResponseCode.TransactionSuccess);
					}

					transactionLog.Status = TransStatus.Successful;
					transactionLog.StatusMessage = "Successful Transanction";
					_db.Transactions.Add(transactionLog);
					_db.SaveChanges();
					transactionResponse.AccountBalance = account.CurrentAccountBalance;
				
					return CoreResponse.GlobalResponse(transactionResponse, ResponseMessage.TransactionFailureMessage, ResponseStatus.Failed, ResponseCode.TransactionFailure);

				}

				catch (Exception exp)
				{
					return CoreResponse.OnFailureResponse(transactionResponse, exp.Message);
				}

			

			}
		}
	}
}
