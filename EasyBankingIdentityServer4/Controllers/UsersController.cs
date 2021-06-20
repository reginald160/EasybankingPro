using EasyBankingIdentityServer4.ViewModel;
using Infrastructure.Persistence;
using Infrastructure.Persistence.DataAccess;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyBankingIdentityServer4.Controllers
{
	public class UsersController : Controller
	{
		
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly SignInManager<ApplicationUser> _signInManager;
		private readonly ApplicationDbContext _db;
		private readonly RoleManager<IdentityRole> _roleManager;

		public UsersController(UserManager<ApplicationUser> userManager,
			SignInManager<ApplicationUser> signInManager, 
			ApplicationDbContext db, RoleManager<IdentityRole> roleManager)
		{
			_userManager = userManager;
			_signInManager = signInManager;
			_db = db;
			_roleManager = roleManager;
		}

		[HttpGet]
		public IActionResult Login(string returnUrl)
		{
			
			var user = new LoginViewModel
			{
				ReturnUrl = returnUrl
			};
			return View(user);
		}
		[HttpPost]
		public async Task<IActionResult> Login(LoginViewModel vm)
		{
			var result = await _signInManager.PasswordSignInAsync(vm.UserName, vm.Password, false, false);
			if (!result.Succeeded)
				return Redirect(vm.ReturnUrl);

			return View();

		}

	}
}
