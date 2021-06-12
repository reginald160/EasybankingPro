using Application.Core.HelperClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common
{
	public class ResponseBody
	{
		
		public string Requestid => LogicHelper.GetTransactionId();
		public int ResponseCode { get; set; }
		public string ResponseMessage { get; set; }
		public string Status { get; set; }
		public object Data { get; set; }


		
	}
}
