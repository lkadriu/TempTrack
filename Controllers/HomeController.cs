using System.Diagnostics;
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
            var customer = cRUDContext.Klientis.ToList();
            var weather = cRUDContext.KategoriteEmotits.ToList();
            var Wind = cRUDContext.NiveletEeres.ToList();
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
