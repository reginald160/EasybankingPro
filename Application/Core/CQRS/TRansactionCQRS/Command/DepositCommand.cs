using Application.Common;
using Application.Core.HelperClass;
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
	public class DepositCommand
	{
		public class Command: IRequest<Response>
		{
			public decimal Amount { get; set; }
			public string AccountNumber { get; set; }
		
		}

		public class Handler : RequestHandler<Command,Response>
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
				TransactionResponse transactionResponse = new TransactionResponse()
				{
					SourceAccount = request.AccountNumber,
					Amount = request.Amount,
					TransactionType = "Deposit",
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

					var account = _db.Accounts.Where(x => x.AccountNumber.Equals(request.AccountNumber)).FirstOrDefault();

					if (account == null)
					{
						response.ResponseCode = ResponseCode.AccountNumberNotFound;
						response.ResponseMessage = ResponseMessage.AccountNumberNotFound;
						response.Data = null;
						return response;
					}
					
					var transactionType = _db.TransactionTypes.Where(x => x.Description == TransactionTypeDescription.Deposit).FirstOrDefault();
					decimal transactionCharge = transactionType.Charge;
					decimal totalAmount = request.Amount - transactionCharge;
					account.CurrentAccountBalance =+ totalAmount ;

					var transactionLog = new TransactionLog
					{
						TransactionTime = Universe.Now,
						TransactionAmount = request.Amount,
						TransactionTypeId = transactionType.Id,
						NewBalance = account.CurrentAccountBalance,
						AccountId = account.Id,
						TransactionRefNumber = LogicHelper.GetTransactionId()

					};
					_db.Accounts.Update(account);
					bool IsCompleted = _db.SaveChanges() > 1;
					if(IsCompleted)
					{
						transactionLog.Status = TransStatus.Successful;
						transactionLog.StatusMessage = "Successful Transanction";
						_db.Transactions.Add(transactionLog);
						_db.SaveChanges();
						transactionResponse.AccountBalance = account.CurrentAccountBalance;
						response.ResponseCode = ResponseCode.TransactionSuccess;
						response.ResponseMessage = ResponseMessage.TransactionSuccessMessage;
						response.Data = transactionResponse;
					}

					transactionLog.Status = TransStatus.Failed;
					transactionLog.StatusMessage = "Failed Transanction";
					_db.Transactions.Add(transactionLog);
					_db.SaveChanges();
					transactionResponse.AccountBalance = account.CurrentAccountBalance;
					response.ResponseCode = ResponseCode.TransactionSuccess;
					response.ResponseMessage = ResponseMessage.TransactionSuccessMessage;
					response.Data = transactionResponse;

					return response;
				}

				catch(Exception exp)
				{
					_logger.LogError($"AN ERROR OCCOURED....{exp.Message}");
				}

				return response;



			}
		}
	}
}
