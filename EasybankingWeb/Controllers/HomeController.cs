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

namespace EasybankingWeb.Controllers
{
	public class HomeController : Controller
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

		public IActionResult Index()
		{
			return View();
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
			return View();
		}



	}
}
