﻿using Microsoft.Extensions.DependencyInjection;
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

namespace Application
{
	public static class ApplicationContainer
	{
		public static IServiceCollection ApplicationInjectionServices(this  IServiceCollection services, IConfiguration configuration)
		{
			

			services.AddAutoMapper(Assembly.GetExecutingAssembly());
			services.AddAutoMapper(typeof(AccountMap));
			services.AddMediatR(typeof(ApplicationContainer));
			services.AddMediatR(Assembly.GetExecutingAssembly());
			services.AddScoped<IUserServices, UserServices>();
			InfrastructureContainer.InfrastructureInjectionServices(services, configuration);

			return services;
		}
	}
}