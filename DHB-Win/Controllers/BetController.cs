using System.Linq;
using System.Threading.Tasks;
using DHB_Win.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace DHB_Win.Controllers
{
    public class BetController : Controller
    {
        private readonly DHBWinDbContext _context;

        public BetController(DHBWinDbContext context)
        {
            _context = context;
        }

        // GET: Bet
        public async Task<IActionResult> Index()
        {
            var dHBWinDbContext = _context.Bets.Include(b => b.UidFk2Navigation);
            return View(await dHBWinDbContext.ToListAsync());
        }

        // GET: Bet/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Bets == null)
            {
                return NotFound();
            }

            var bet = await _context.Bets
                .Include(b => b.UidFk2Navigation)
                .FirstOrDefaultAsync(m => m.BetId == id);
            if (bet == null)
            {
                return NotFound();
            }

            return View(bet);
        }

        // GET: Bet/Create
        public IActionResult Create()
        {
            ViewData["UidFk2"] = new SelectList(_context.Users, "Uid", "Uid");
            return View();
        }

        // POST: Bet/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BetId,UidFk2,Title,ExpPoints,Reward,Description")] Bet bet)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bet);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["UidFk2"] = new SelectList(_context.Users, "Uid", "Uid", bet.UidFk2);
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

            ViewData["UidFk2"] = new SelectList(_context.Users, "Uid", "Uid", bet.UidFk2);
            return View(bet);
        }

        // POST: Bet/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BetId,UidFk2,Title,ExpPoints,Reward,Description")] Bet bet)
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

            ViewData["UidFk2"] = new SelectList(_context.Users, "Uid", "Uid", bet.UidFk2);
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
                .Include(b => b.UidFk2Navigation)
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
                return Problem("Entity set 'DHBWinDbContext.Bets'  is null.");
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