
using IdentityModel.Client;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace EasybankingAPI.Controllers
{
	public class SecretController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;
		
		public SecretController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}
		//[Route("/secret")]
		//[HttpGet]
		//[Authorize]
		//public string Index()
		//{
		//	return "secret message from EasyBankAPI";
		//}
		[HttpGet]
		public async Task<IActionResult> RetrieveToken()
		{
			var serverClient = _httpClientFactory.CreateClient();
			var discoveryDocument = serverClient.GetDiscoveryDocumentAsync("https://localhost:44315");//IdentityServer4Url

			var tokenResponse = serverClient.RequestClientCredentialsTokenAsync(
				new ClientCredentialsTokenRequest
			{
				ClientId = "client_Id",
				ClientSecret = "client_secret",
				Scope = "EasyBankingAPI",
				Address = discoveryDocument.Result.TokenEndpoint
			});;

			var appClient = _httpClientFactory.CreateClient();
			appClient.SetBearerToken(tokenResponse.Result.AccessToken);
			var response = await appClient.GetAsync("https://localhost:44324/secret");
			var content = await response.Content.ReadAsStringAsync();

			return Ok( new 
			{
				access_token = tokenResponse.Result.AccessToken,
				message = content
			});

		}


	}
}
