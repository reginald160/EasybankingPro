using Domain.Entities.ChatModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Domain.Enums;

namespace Application.Core.DTOs.ChatDTOs
{
   public class ChatDTO
    {
        public ChatDTO()
        {
            Messages = new HashSet<Message>();
            Users = new HashSet<ApplicationUser>();
        }
        public virtual ICollection<Message> Messages { get; set; }
        public virtual ICollection<ApplicationUser> Users { get; set; }
        public ChatType ChatType { get; set; }
    }
}
