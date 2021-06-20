using Infrastructure.Persistence;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EasyBankingIdentityServer4
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var host = CreateHostBuilder(args).Build();
			using (var scope = host.Services.CreateScope())
			{
				var userManager = scope.ServiceProvider
					.GetRequiredService<UserManager<ApplicationUser>>();
				var user = new ApplicationUser
				{
					Name = "Bob",
					Email = "ozougwuifeanyi160@gmail.com",
					UserName = "bob"
				};
				userManager.CreateAsync(user, "bob").GetAwaiter().GetResult();
			};
			host.Run();


		}

		public static IHostBuilder CreateHostBuilder(string[] args) =>
			Host.CreateDefaultBuilder(args)
				.ConfigureWebHostDefaults(webBuilder =>
				{
					webBuilder.UseStartup<Startup>();
				});
	}
}
