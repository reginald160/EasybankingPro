using Application.Core.DTOs.ChatDTOs;
using Application.Core.HelperClass;
using Application.Core.Responses;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using DotNetOpenAuth.InfoCard;
using Infrastructure.Persistence.DataAccess;
using MediatR;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Core.CQRS.ChatCQRS.Query
{
	public class ChatsQuerry
	{
		public class Query : IRequest<Response>
		{

		}
		public class Handler : IRequestHandler<Query, Response>
		{
			private readonly ApplicationDbContext _db;
			private readonly IMapper _mapper;

			public Handler(ApplicationDbContext db, IMapper mapper)
			{
				_db = db;
				_mapper = mapper;
			}

			public async Task<Response> Handle(Query request, CancellationToken cancellationToken)
			{

				Response response = new Response();
				try
				{
					var chats = await _db.Chats.Include(x=>x.Users).Include(x=>x.Messages).Where(x => !x.Users.Any(y => y.Id == _db.User.FindFirst(ClaimTypes.NameIdentifier).Value))
						.ProjectTo<ChatDTO>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);

					response.ResponseCode = ResponseCode.SuccesFullOperation;
					response.ResponseMessage = ResponseMessage.SuccesFullOperationMessage;
					response.Data = chats;
					return response;
				}
				catch (Exception exp)
				{
					response.ResponseCode = ResponseCode.FailedOperation;
					response.ResponseMessage = exp.Message;
					response.Data = null;
					return response;
				}
			}
		}
	}
}
