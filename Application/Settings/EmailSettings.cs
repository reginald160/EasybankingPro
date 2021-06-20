using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Application.Settings
{
	public class EmailSettings
	{
		public string OriginEmail { get; set; }
		public string Host { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
		public int Port { get; set; }
		public bool EnableSsl { get; set; }

    }
}
