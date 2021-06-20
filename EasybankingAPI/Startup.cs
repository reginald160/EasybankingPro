using Application;
using Application.Core.HelperClass;
using EasybankingAPI.Helper;
using IdentityServer4.AccessTokenValidation;
using Infrastructure;
using Infrastructure.Persistence;
using Infrastructure.Persistence.DataAccess;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasybankingAPI
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



			services.AddAuthentication("Bearer")
			// Adding Jwt Bearer  
			.AddJwtBearer("Bearer", options =>
			{
				options.SaveToken = true;
				options.RequireHttpsMetadata = false;
				//IdentityServer4b
				options.Authority = "https://localhost:44315/";
				options.Audience = "EasyBankingAPI";
				
			});
			
			services.AddControllers();
		
			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo { Title = "EasybankingAPI", Version = "v1" });
			});
			
			services.AddAutoMapper(typeof(Startup).Assembly);
			ApplicationContainer.ApplicationInjectionServices(services, Configuration);



		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseSwagger();
				app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "EasybankingAPI v1"));
			}

			app.UseHttpsRedirection();

			app.UseRouting();

			//app.UseSession();

			app.UseAuthentication();
			app.UseAuthorization();

			
			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
