using Application.Common;
using Application.Core.HelperClass;
using Application.Core.Responses;
using Application.Core.ViewModels.AccountViewModel;
using Application.Identyity.UserServices;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Persistence;
using Infrastructure.Persistence.DataAccess;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static Domain.Enums;

namespace Application.Core.CQRS.AccountCQRS.Command
{
	public class CreateAccountCommand
	{
        public class Command : IRequest<Response>
        {
			public CreateAccountDTO Account { get; set; }
		}

        public class Handler : IRequestHandler<Command, Response>
        {
            private readonly ApplicationDbContext _db;
            private readonly IMapper _mapper;
            private readonly ILogger<Handler> _logger;
            private readonly IUserServices _userServices;
            AccountResponse accountResponse = new AccountResponse();

			public Handler(ApplicationDbContext db, IMapper mapper, ILogger<Handler> logger, UserManager<ApplicationUser> userManager, IUserServices userServices = null)
			{
				_db = db;
				_mapper = mapper;
				_logger = logger;
				_userServices = userServices;
			}

			public async Task<Response> Handle(Command request, CancellationToken cancellationToken)
			{

                
                try
                {
                    var record = _mapper.Map<Account>(request.Account);
                    _db.Accounts.Add(record);
                     var user = new ApplicationUser
                    {
                        UserName = request.Account.Email,
                        Email = request.Account.Email,
                        //Descriminator = UserDescriminator.Customer
                    };
                    await _userServices.Creatidentityuser(user, "EasyBanking160@");

                    _db.SaveChanges();
                   
                    
                    accountResponse.AccountNumber = record.FullName;
                    accountResponse.AccountName = record.AccountNumber;

                    return CoreResponse.OnSaveResponse(accountResponse);
                }
                catch (Exception exp)
                {
                    return CoreResponse.OnFailureResponse(accountResponse, exp.Message);

                }

            }

          
        }
    }
}
