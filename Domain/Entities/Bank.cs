using Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Bank : BaseModel
    {
     
        [Required]
        public string Name { get; set; }

        [Required]
        public string SwiftCode { get; set; }

        [Required]
        public string Location { get; set; }

        [Required]
        public string ApiKey { get; set; }

        [Required]
        public string ApiAddress { get; set; }

        public string PaymentUrl { get; set; }

        public string CardPaymentUrl { get; set; }

        public string BankIdentificationCardNumbers { get; set; }
    }
}
