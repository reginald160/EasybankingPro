using Domain.Common;
using Domain.StaticVariables;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Domain.StaticVariables.ModelConstants;

namespace Domain.Entities
{
    public class Card : BaseModel
    {
        [Required]
        public string Number { get; set; }

        [Required]
        [MaxLength(ModelConstants.Card.NameMaxLength)]
        public string Name { get; set; }

        [Required]
        [StringLength(ModelConstants.Card.ExpiryDateMaxLength, MinimumLength = ModelConstants.Card.ExpiryDateMaxLength)]
        public string ExpiryDate { get; set; }

        [Required]
        [StringLength(ModelConstants.Card.SecurityCodeMaxLength, MinimumLength = ModelConstants.Card.SecurityCodeMaxLength)]
        public string SecurityCode { get; set; }

        [Required]
        public Guid? UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual Customer User { get; set; }

        [Required]
        public Guid? AccountId { get; set; }
        [ForeignKey("AccountId")]
        public virtual Account Account { get; set; }
    }
}
