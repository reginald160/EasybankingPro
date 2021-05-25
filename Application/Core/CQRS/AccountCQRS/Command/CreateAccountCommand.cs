using Application.Core.ViewModels.AccountViewModel;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Persistence.DataAccess;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core.CQRS.AccountCQRS.Command
{
	public class CreateAccountCommand
	{
        public class Command : IRequest<CreateAccountDTO>
        {
			public CreateAccountDTO Account { get; set; }
		}

        public class Handler : RequestHandler<Command, CreateAccountDTO>
        {
            private readonly ApplicationDbContext _db;
            private readonly IMapper _mapper;

			public Handler(ApplicationDbContext db, IMapper mapper)
			{
				_db = db;
				_mapper = mapper;
			}

			protected override CreateAccountDTO Handle(Command request)
            {
                var account = _mapper.Map<Account>(request.Account);
                _db.Accounts.Add(account);

                return _db.SaveChanges() > 1 ? request.Account : null;
               
            }
        }
    }
}
