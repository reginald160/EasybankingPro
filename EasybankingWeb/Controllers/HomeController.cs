using EasybankingWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using Microsoft.Extensions.Options;
using EasybankingWeb.Settings;
using System.Net.Http.Headers;
using Newtonsoft.Json.Linq;
using System.IdentityModel.Tokens.Jwt;

namespace EasybankingWeb.Controllers
{
	public class HomeController : BaseController
	{
		private readonly ILogger<HomeController> _logger;
		private readonly HttpClient _client;
		private readonly IOptions<JWTSettings> _settings;

		public HomeController(ILogger<HomeController> logger,IHttpClientFactory httpClientFactory  ,IOptions<JWTSettings> settings)
		{
			_logger = logger;
			_client = httpClientFactory.CreateClient();
			_settings = settings;
		}

		public async Task<IActionResult> Index()
		{
			//var accessToken = await HttpContext.GetTokenAsync("access_token");
			//var client = new HttpClient();
			//client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
			//var content = await client.GetStringAsync("https://localhost:6001/identity");
			//ViewBag.Json = JArray.Parse(content).ToString();

			var accessToken = await HttpContext.GetTokenAsync("access_token");
			var idToken = await HttpContext.GetTokenAsync("id_token");
			var refreshToken = await HttpContext.GetTokenAsync("refresh");
			if(accessToken != null)
			{
				var _acesstoken = new JwtSecurityTokenHandler().ReadJwtToken(accessToken);
				var _idtoken = new JwtSecurityTokenHandler().ReadJwtToken(idToken);


			}

			this.ShowSuccessMessage("Hello");
			return View();
		}

		[Route("signin-oidc")]
		public IActionResult Oidc()
		{
			return RedirectToAction("Index", "Home");
		}
		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
		public async Task<IActionResult> Secret()
		{
			var serverResponse = await _client.GetAsync(_settings.Value.ValidIssuer+$"/Index");
			var serverHeader = await _client.GetAsync(_settings.Value.ValidIssuer + $"/Index");
			var accessToken = await HttpContext.GetTokenAsync(_settings.Value.Token);
			_client.DefaultRequestHeaders.Add("Authorization", $"Bearer{accessToken}");


			var client = new HttpClient();
			client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
			var content = await client.GetStringAsync("https://localhost:6001/identity");
			ViewBag.Json = JArray.Parse(content).ToString();
			return View("json");
		}



	}
}
