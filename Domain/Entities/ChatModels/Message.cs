using Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.Entities.ChatModels
{
    public class Message : BaseModel
    {
        public string SenderName { get; set; }
        public string Text { get; set; }
        public DateTime? TimeStamp { get; set; }
        public Guid? ChatId { get; set; }
        [JsonIgnore, ForeignKey("ChatId")]
        public virtual Chat Chat { get; set; }
    }
}
