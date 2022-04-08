using System.Diagnostics;
using DHB_Win.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DHB_Win.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly dhbwinContext _context;

        public HomeController(ILogger<HomeController> logger, dhbwinContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            string? test = _context.Achievement.Find("test").Title;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}