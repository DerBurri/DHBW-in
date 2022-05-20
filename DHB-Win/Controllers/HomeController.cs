using System.Diagnostics;
using DHB_Win.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Controller = DHB_Win.Models.Controller;

namespace DHB_Win.Controllers
{
    [Route("home")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DHBWinDbContext _context;


        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            // _context = context;
        }

        [Route("")]
        [Route("index")]
        [Route("~/")]
        public IActionResult Index()
        {
            //string? test = _context.Achievement.Find("test").Title;
            return View();
        }

        [Route("calendar")]
        public IActionResult Calendar()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }

        [Route("auftraege")]
        public IActionResult Auftraege()
        {
            throw new System.NotImplementedException();
            return View();
        }
    }
}