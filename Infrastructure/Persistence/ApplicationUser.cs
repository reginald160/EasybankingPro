using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using static Domain.Enums;

namespace Infrastructure.Persistence
{

    public partial class ApplicationUser : IdentityUser/*, IEntity<string>*/
    {
        // Other properties

        //object IEntity.Id
        //{
        //    get { return this.Id; }
        //    set { Id =( string)value; }
        //}
      
        public string Name { get; set; }
        public UserDescriminator Descriminator { get; set; }
        private DateTime? createdDate;
        [DataType(DataType.DateTime)]
        public DateTime CreatedDate
        {
            get { return createdDate ?? DateTime.UtcNow; }
            set { createdDate = value; }
        }

        [DataType(DataType.DateTime)]
        public DateTime? ModifiedDate { get; set; }

        public string CreatedBy { get; set; }

        public string ModifiedBy { get; set; }

        [Timestamp]
        public byte[] Version { get; set; }
    }
    
}
