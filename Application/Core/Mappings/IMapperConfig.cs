using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core.Mappings
{
	public interface IMapperConfig
	{
		void Mapping(Profile profile);
	}
}
