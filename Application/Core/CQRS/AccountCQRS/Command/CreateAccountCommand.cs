using Application.Common;
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
	public class CreateAccountCommand
	{
        public class Command : IRequest<Response>
        {
			public CreateAccountDTO Account { get; set; }
		}

        public class Handler : RequestHandler<Command, Response>
        {
            private readonly ApplicationDbContext _db;
            private readonly IMapper _mapper;
            private readonly ILogger<Handler> _logger;
			public string Message { get; set; }

			public Handler(ApplicationDbContext db, IMapper mapper, ILogger<Handler> logger)
			{
				_db = db;
				_mapper = mapper;
				_logger = logger;
			}

			protected override Response Handle(Command request)
            {
                Response response = new Response();
                AccountResponse accountResponse = new AccountResponse();

                try
                {
                   
                     var record = _mapper.Map<Account>(request.Account);
                    _db.Accounts.Add(record);
                    _db.SaveChanges();
                    response.ResponseCode = ResponseCode.SuccesFullOperation;
                    response.ResponseMessage = ResponseMessage.SuccesFullOperationMessage;
                    accountResponse.AccountName = request.Account.AccountNumber;
                    response.Data = accountResponse;

                    return response;
                }
                catch (Exception exp)
                {
                    //_logger.LogError($"AN ERROR OCCOURED....{exp.Message}");
                    Message = exp.Message;
                    response.ResponseCode = ResponseCode.FailedOperation;
                    response.ResponseMessage = exp.Message;

                    return response;
                }

                
            }
        }
    }
}
