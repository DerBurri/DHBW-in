using System.Linq;
using System.Security.Claims;
using DHB_Win.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DHB_Win.Controllers
{
    [AllowAnonymous]
    [Route("home")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly dhbwinContext _context;

        public HomeController(ILogger<HomeController> logger, dhbwinContext context)
        {
            _logger = logger;
            _context = context;
        }

        [Route("")]
        [Route("index")]
        [Route("~/")]
        public IActionResult Index()
        {
            ViewBag.Bets = _context.Bets.Include(x => x.User).Select(x => x).ToList();
            ViewBag.Jobs = _context.Jobs.Include(x => x.Provider).Include(x => x.Worker).Select(x => x).ToList();
            ViewBag.AchievedAchievement = _context.AchievedAchievements.Select(x => x).ToList();
            ViewBag.Achievement = _context.Achievements.Select(x => x).ToList();
            ViewBag.User = _context.Users.Select(x => x)
                .Where(x => x.Id == User.FindFirstValue(ClaimTypes.NameIdentifier)).ToList();
         ViewBag.Betoption = _context.BetOptions.Select(x => x).Include(x=>x.Bet).ToList();
            return View();
        }

        [Route("Contact")]
        public IActionResult Contact()
        {
            //string? test = _context.Achievement.Find("test").Title;
            return View();
        }
    }
}