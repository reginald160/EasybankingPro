using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasybankingWeb.Controllers
{
	public class AccountController : Controller
	{
		[Authorize]
		public IActionResult AccountOpening()
		{
			return View();
		}
	}
}
