using Application.Core.DTOs.ChatDTOs;
using AutoMapper;
using Domain.Entities.ChatModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core.Mappings
{
   public class ChatMap : Profile
    {
        public ChatMap()
        {
            CreateMap<Chat, ChatDTO>().ReverseMap();
            CreateMap<Message, MessageDTO>().ReverseMap();
        }
    }
}
