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

namespace Application.Core.HelperClass
{
	public static class ApplicationContainer
	{
		public static IServiceCollection ApplicationInjectionServices(this  IServiceCollection services, IConfiguration configuration)
		{
			

			services.AddAutoMapper(Assembly.GetExecutingAssembly());
			services.AddAutoMapper(typeof(IMappingProfile));
			services.AddMediatR(typeof(ApplicationContainer));
			services.AddMediatR(Assembly.GetExecutingAssembly());
			InfrastructureContainer.InfrastructureInjectionServices(services, configuration);


			return services;
		}
	}
}
