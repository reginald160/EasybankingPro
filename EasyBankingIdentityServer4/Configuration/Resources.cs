using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityModel;
using IdentityServer3.Core.Services.InMemory;
using IdentityServer4.Models;
using IdentityServer4.Services;

namespace EasyBankingIdentityServer4.Configuration
{
	public  static class Resources
	{
		public static IEnumerable<ApiResource> GetApiResources()
		{
			return new List<ApiResource>
			{
				new ApiResource("EasyBankingAPI")
			};
		}

		public static IEnumerable<IdentityResource> GetIdentityResources() =>
			new List<IdentityResource>
			{
				new IdentityResources.OpenId(),
				new IdentityResources.Profile()
			};
	}
}
