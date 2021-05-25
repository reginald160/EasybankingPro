using Infrastructure.Identity;
using Infrastructure.Persistence.DataAccess;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace Infrastructure
{
	public static  class InfrastructureContainer
	{
		
		public static IServiceCollection InfrastructureInjectionServices(this IServiceCollection services, IConfiguration configuration)
		{
			
			services.AddDbContext<ApplicationDbContext>(options =>
				   options.UseSqlServer(
					   configuration.GetConnectionString("DefaultConnection"), x =>
					   x.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

			//services.AddIdentity<ApplicationUser, IdentityRole>(options =>
			//{
			//	options.Stores.MaxLengthForKeys = 128;
			//	options.SignIn.RequireConfirmedAccount = true;
			//});
			services.AddTransient<IUserServices, UserServices>();
			return services;
		}


	}
}
