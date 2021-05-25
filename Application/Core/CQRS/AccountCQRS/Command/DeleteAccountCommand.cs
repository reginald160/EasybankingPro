using Infrastructure.Persistence.DataAccess;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core.CQRS.AccountCQRS.Command
{
    public class DeleteAccountCommand
    {

        public class Command : IRequest
        {
            public Guid Id { get; set; }
        }

        public class Handler : RequestHandler<Command>
        {
            private readonly ApplicationDbContext _db;

            public Handler(ApplicationDbContext db)
            {
                _db = db;
            }

            protected override void Handle(Command request)
            {
                var account = _db.Accounts.Where(x => x.Id.Equals(request.Id)).FirstOrDefault();

                _db.Accounts.Remove(account);
            }
        }
    }
}
