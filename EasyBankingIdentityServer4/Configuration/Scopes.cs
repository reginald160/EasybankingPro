using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.Models;

namespace EasyBankingIdentityServer4.Configuration
{
	public class Scopes
	{
		public static IEnumerable<IdentityResource> GetIdentityResources() =>
			new List<IdentityResource>
			{
				new IdentityResources.OpenId(),
				new IdentityResources.Email()
			};

		public static IEnumerable<ApiResource> GetApis() =>
			new List<ApiResource>
			{
				new ApiResource ("EasyBankingAPI"),
			};
	}
}
