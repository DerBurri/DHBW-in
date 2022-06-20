using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using DHB_Win.Data;
using DHB_Win.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DHB_Win.Controllers
{
    public class BetController : Controller
    {
        private readonly dhbwinContext _context;
        private readonly UserManager<User> _userManager;

        public BetController(dhbwinContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Bet
        public async Task<IActionResult> Index()
        {
            ViewBag.User = _context.Users.Select(x => x)
                .Where(x => x.Id == User.FindFirstValue(ClaimTypes.NameIdentifier)).ToList();
            return _context.Bets != null
                ? View(await _context.Bets.Include(u => u.User).ToListAsync())
                : Problem("Entity set 'dhbwinContext.Bets'  is null.");
        }

        // GET: Bet/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Bets == null)
            {
                return NotFound();
            }

            var bet = await _context.Bets
                .FirstOrDefaultAsync(m => m.BetId == id);
            if (bet == null)
            {
                return NotFound();
            }

            return View(bet);
        }

        
        //Get History
        public async Task<IActionResult> History()
        {
            ViewBag.User = _context.Users.Select(x => x)
                .Where(x => x.Id == User.FindFirstValue(ClaimTypes.NameIdentifier)).ToList();
            return View(await _context.Bets.Include(u => u.User).Select(x => x).Where(x => x.Finished).ToListAsync());
        }
        
        // GET: Bet/Create
        public IActionResult Create()
        {
            return View();
        }


        // POST: Bet/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BetId,Title,ExpPoints,Reward,Description,CreationDate")] Bet bet)
        {
            bet.User = await _userManager.GetUserAsync(HttpContext.User);
            bet.CreationDate = DateTime.UtcNow;
            ModelState.Clear();
            TryValidateModel(bet);
            if (ModelState.IsValid)
            {
                _context.Add(bet);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(bet);
        }

        // GET: Bet/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Bets == null)
            {
                return NotFound();
            }

            var bet = await _context.Bets.FindAsync(id);
            if (bet == null)
            {
                return NotFound();
            }

            return View(bet);
        }

        // POST: Bet/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,
            [Bind("BetId,Title,ExpPoints,Reward,Description,CreationDate")]
            Bet bet)
        {
            if (id != bet.BetId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bet);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BetExists(bet.BetId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return RedirectToAction(nameof(Index));
            }

            return View(bet);
        }

        
        // GET: Bet/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Bets == null)
            {
                return NotFound();
            }

            var bet = await _context.Bets
                .FirstOrDefaultAsync(m => m.BetId == id);
            
            if (bet == null)
            {
                return NotFound();
            }

            return View(bet);
        }

        // POST: Bet/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Bets == null)
            {
                return Problem("Entity set 'dhbwinContext.Bets'  is null.");
            }

            var bet = await _context.Bets.FindAsync(id);
            if (bet != null)
            {
                _context.Bets.Remove(bet);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BetExists(int id)
        {
            return (_context.Bets?.Any(e => e.BetId == id)).GetValueOrDefault();
        }
    }
}