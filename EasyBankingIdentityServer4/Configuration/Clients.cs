using System;
using IdentityModel;
using IdentityServer4.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static IdentityServer4.IdentityServerConstants;

namespace EasyBankingIdentityServer4.Configuration
{
	public class Clients
	{

		public static IEnumerable<Client> GetClients() =>
			new List<Client>
			{
				new Client
				{
					ClientId = "client_Id",
					 // secret for authentication
					ClientSecrets = {new Secret("client_secret".ToSha256())},
					  // no interactive user, use the clientid/secret for authentication
					AllowedGrantTypes = GrantTypes.Code,		
					RedirectUris = { "https://localhost:44372/signin-oidc" },
					  //// where to redirect to after logout
					PostLogoutRedirectUris = { "http://localhost:44372/signout-callback-oidc" },
					AllowedScopes = {
						"EasyBankingAPI",
						IdentityServer4.IdentityServerConstants.StandardScopes.OpenId,
						IdentityServer4.IdentityServerConstants.StandardScopes.Profile
					},
					RequireConsent = false


				},
				 new Client
				 {
					ClientId = "ro.client",
					AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,

					ClientSecrets =
					 {
					 new Secret("secret".Sha256())
					 },
			        AllowedScopes = { "EasyBankingAPI" }
		}

			};

	}
}
