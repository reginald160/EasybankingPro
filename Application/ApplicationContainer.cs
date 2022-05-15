using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using System.Reflection;
using Application.Core.Mappings;
using MediatR;
using Infrastructure;
using Microsoft.Extensions.Configuration;
using Application.Identyity.UserServices;
using Application.Core.Behaviour;
using Infrastructure.Persistence;
using Microsoft.AspNetCore.Identity;
using Application.Common;
using Application.Settings;
using Application.Core.Notification;
using Twilio.Clients;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

namespace Application
{
	public static class ApplicationContainer
	{
		public static IServiceCollection ApplicationInjectionServices(this  IServiceCollection services, IConfiguration configuration)
		{

			services.AddSingleton(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
			services.AddAutoMapper(Assembly.GetExecutingAssembly());
			services.AddAutoMapper(typeof(AccountMap));
			services.AddMediatR(typeof(ApplicationContainer));
			services.AddMediatR(Assembly.GetExecutingAssembly());
			services.AddScoped<IUserServices, UserServices>();
			services.AddSignalR();
			//Application settings Services
			services.Configure<AccountSettings>(configuration.GetSection("AccountSettings"));
			services.Configure<JWTSettings>(configuration.GetSection("JWTSettings"));
			services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));
			services.Configure<SMSSettings>(configuration.GetSection("SMSSettings"));
			services.AddTransient<IMessageNotification, MessageNotification>();
			services.AddHttpClient<ITwilioRestClient, CustomTwilioClient>(client =>
			client.DefaultRequestHeaders.Add("X-Custom-Header", "HttpClientFactory-Sample"));
			//Infracture Layer Service Container
			InfrastructureContainer.InfrastructureInjectionServices(services, configuration);

			return services;
		}

		public  static void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			
		}
	}
}
