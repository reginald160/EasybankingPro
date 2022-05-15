using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Settings
{
	public class SendGridSetting
	{
		[Required]
		public string ApiKey { get; set; }
	}
}
