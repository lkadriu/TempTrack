﻿using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TempTrackApp.Models;

namespace TempTrackApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly CRUDContext cRUDContext;

        public HomeController(ILogger<HomeController> logger, CRUDContext cRUDContext)
        {
            _logger = logger;
            this.cRUDContext = cRUDContext;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Location()
        {
            return View();
        }
        public IActionResult Search()
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
    }
}
