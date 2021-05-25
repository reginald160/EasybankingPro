using Application.Core.DTOs.TransactionDTOs;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Persistence.DataAccess;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core.CQRS.Commands.TransactionTypeCommand
{

		public class AddTransactionTypeHandler : RequestHandler<AddTransactionTypeDTO>
		{
			private readonly ApplicationDbContext _db;
		private readonly IMapper _mapper;

		public AddTransactionTypeHandler(ApplicationDbContext db, IMapper mapper)
		{
			_db = db;
			_mapper = mapper;
		}

		protected override void Handle(AddTransactionTypeDTO request)
			{
			var entity = _mapper.Map<TransactionType>(request);
			_db.TransactionTypes.Add(entity);
			}
		}

}



