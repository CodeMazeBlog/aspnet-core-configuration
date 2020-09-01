using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using ProjectConfigurationDemo.Models;
using ProjectConfigurationDemo.Services;

namespace ProjectConfigurationDemo.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly TitleConfiguration _homePageTitleConfiguration;
		private readonly ITitleColorService _titleColorService;

		public HomeController(ILogger<HomeController> logger,
			IOptionsSnapshot<TitleConfiguration> homePageTitleConfiguration,
			ITitleColorService titleColorService)
		{
			_logger = logger;
			_homePageTitleConfiguration = homePageTitleConfiguration.Get("HomePage");
			_titleColorService = titleColorService;
		}

		public IActionResult Index()
		{
			var homeModel = new HomeModel
			{
				Configuration = _homePageTitleConfiguration
			};

			homeModel.Configuration.Color = _titleColorService.GetTitleColor("HomePage");

			return View(homeModel);
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
	}
}
