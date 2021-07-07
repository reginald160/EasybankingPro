
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
using Infrastructure.Persistence;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

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

			services.AddDbContext<ApplicationDbContext>(options =>
			{
				options.UseInMemoryDatabase("Memory");
			});

			// Identity
			services.AddIdentity<ApplicationUser, IdentityRole>(options =>
			{
				options.User.RequireUniqueEmail = false;
				options.Stores.MaxLengthForKeys = 128;
				options.SignIn.RequireConfirmedAccount = false;
				options.Password.RequireUppercase = false;
				options.Password.RequireNonAlphanumeric = false;
				options.Password.RequireDigit = false;
			
				//options.SignIn.RequireConfirmedEmail = true;
			})
			.AddEntityFrameworkStores<ApplicationDbContext>()
			.AddDefaultTokenProviders();

			//Authentificvation
			


			return services;
		}


	}
}
