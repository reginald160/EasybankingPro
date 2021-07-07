
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.IdentityModel.Tokens.Jwt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Infrastructure.Persistence.DataAccess;
using Infrastructure;
using EasybankingAPI.Helper;
using Infrastructure.Persistence;
using EasyBankingIdentityServer4.Configuration;

namespace EasyBankingIdentityServer4
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			InfrastructureContainer.InfrastructureInjectionServices(services, Configuration);
			services.ConfigureApplicationCookie(option =>
			{
				option.Cookie.Name = IdentConstants.CookieName;
				//option.LoginPath = IdentConstants.LoginPath;
			});

			services.AddControllersWithViews();
		
			// configure identity server with in-memory stores, keys, clients and resources
			services.AddIdentityServer()
				//.AddTemporarySigningCredential()
				//.AddAspNetIdentity<ApplicationUser>()
				.AddInMemoryApiResources(Resources.GetApiResources())
				.AddInMemoryIdentityResources(Resources.GetIdentityResources())
				.AddInMemoryClients(Clients.GetClients())
				 .AddTestUsers(TestUsers.Users)
				.AddDeveloperSigningCredential();
		
			
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseMigrationsEndPoint();
			}
			else
			{
				app.UseExceptionHandler("/Home/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}
			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();

			//app.UseAuthentication();
			//app.UseAuthorization();
			app.UseIdentityServer();
			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllerRoute(
					name: "default",
					pattern: "{controller=Home}/{action=Index}/{id?}");
				//endpoints.MapRazorPages();
			});
		}
	}
}
