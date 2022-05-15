using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace EasybankingWeb.Controllers
{
	[Authorize]
	public class AccountController : BaseController
	{
		
		public  async Task<IActionResult> AccountOpening()
		{


			return View();
		}
	}
}
