using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasybankingWeb.Settings
{
	public class JWTSettings
	{
		public string ValidAudience { get; set; }
		public string ValidIssuer { get; set; }
		public string Secret { get; set; }
		public string Token { get; set; }
		public string APIUser { get; set; }
	}
}
