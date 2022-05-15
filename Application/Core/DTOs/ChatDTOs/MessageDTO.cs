using Application.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core.DTOs.ChatDTOs
{
    public class MessageDTO : BaseDTO
    {
        public string SenderName { get; set; }
        public string Text { get; set; }
        public DateTime? TimeStamp { get; set; }
        public Guid? ChatId { get; set; }

    }
}
