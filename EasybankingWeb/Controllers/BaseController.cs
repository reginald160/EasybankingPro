using EasybankingWeb.StaticVariables;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace EasybankingWeb.Controllers
{
	public abstract class BaseController : Controller
	{
		protected IActionResult RedirectToHome() => this.RedirectToAction("Index", "Home");

        protected string GetCurrentUserId()
        {
            if (!this.User.Identity.IsAuthenticated)
                return null;
      
            var claim = this.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
            return claim?.Value;
        }
        protected void ShowErrorMessage(string message)
		{
            this.TempData[GlobalConstant.TempDataErrorMessageKey] = message;
		}
        protected void ShowSuccessMessage(string message)
        {
            this.TempData[GlobalConstant.TempDataSuccessMessageKey] = message;
        }

    }
}
