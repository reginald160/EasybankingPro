using Domain.Entities;
using Infrastructure.Persistence.DataAccess;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core.CQRS.Queries.TransanctionTypes
{
	public class GetAllTransactionTypeQuery : IRequest<IEnumerable<TransactionType>> 
	{
      

    }

    public class GetAllTransactionTypeHandler : RequestHandler<GetAllTransactionTypeQuery, IEnumerable<TransactionType>>
    {
        private readonly ApplicationDbContext _db;
        public GetAllTransactionTypeHandler(ApplicationDbContext db)
        {
            _db = db;
        }

        protected override IEnumerable<TransactionType> Handle(GetAllTransactionTypeQuery request)
        {
            return _db.TransactionTypes.Where(x => x.Deleted.Equals(false)).ToList() ?? null;
        }
    }



}
