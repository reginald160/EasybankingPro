using Application.Core.DTOs.ChatDTOs;
using Application.Core.HelperClass;
using Application.Core.Responses;
using AutoMapper;
using Domain.Entities.ChatModels;
using Infrastructure.Persistence.DataAccess;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Core.CQRS.ChatCQRS.Command
{
	public class CreateMessageCommand
	{

		public class Command : IRequest<Response>
		{
			public MessageDTO Message { get; set; }
		}

		public class Handler : IRequestHandler<Command, Response>
		{
			private readonly ApplicationDbContext _db;
			private readonly IMapper _mapper;
			private static string _bankSettlement;

			public Handler(ApplicationDbContext db, IMapper mapper)
			{
				_db = db;
				_mapper = mapper;
			}


			public async Task<Response> Handle(Command request, CancellationToken cancellationToken)
			{
				try
				{
					var message = _mapper.Map<Message>(request.Message);
					await _db.Messages.AddAsync(message);
					_db.SaveChanges();
					return CoreResponse.GlobalResponse(message, "The transaction was successful", ResponseStatus.Success, ResponseCode.TransactionSuccess);
				}
				catch (Exception exp)
				{
					return CoreResponse.GlobalResponse(null, exp.Message, ResponseStatus.Failed, ResponseCode.TransactionFailure);

				}
			}
		}
	}
}
