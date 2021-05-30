using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core.Mappings
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			ApplyMappingFromAssembly(Assembly.GetExecutingAssembly());
		}

		private void ApplyMappingFromAssembly(Assembly assembly)
		{

			var types = Assembly.Load("Application").GetTypes().
			Where(type => !string.IsNullOrEmpty(type.Namespace)).
			Where(type => type.GetInterface(typeof(IMapFrom<>).FullName) != null).ToList();



			foreach (var type in types)
			{
				Activator.CreateInstance(type);
				var Instance = Activator.CreateInstance(type);
				var methodInfo = type.GetMethod("Mapping");
				

				if(methodInfo!=null)
					methodInfo?.Invoke(Instance, new object[] { this });
			}
		}
	}
}
