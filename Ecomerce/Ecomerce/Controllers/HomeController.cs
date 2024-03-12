﻿using Ecomerce.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Ecomerce.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;

		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}

		public IActionResult Index()
		{
			
			return RedirectToAction("NewCollections", "Collections");
		}

		public IActionResult Privacy()
		{
			return View();
		}
        public IActionResult Help()
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