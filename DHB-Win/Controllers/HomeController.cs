using System.Diagnostics;
using System.Linq;
using DHB_Win.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DHB_Win.Controllers
{
    [Route("home")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly dhbwinContext _context;

        public HomeController(ILogger<HomeController> logger, dhbwinContext context)
        {
            _logger = logger;
            _context=context;
        }

        [Route("")]
        [Route("index")]
        [Route("~/")]
        public IActionResult Index()
        {
            ViewBag.Bets = _context.Bets.Select(x => x).ToList();
            return View();
        }

        [Route("Contact")]
        public IActionResult Contact()
        {
            //string? test = _context.Achievement.Find("test").Title;
            return View();
        }


        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        // public IActionResult Error()
        // {
        //    return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        // }
        //brauchen wir sowas? 
    }
}