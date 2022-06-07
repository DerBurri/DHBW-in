using System.Linq;
using System.Threading.Tasks;
using DHB_Win.Data;
using DHB_Win.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace DHB_Win.Views
{
    public class Test : Controller
    {
        private readonly dhbwinContext _context;

        public Test(dhbwinContext context)
        {
            _context = context;
        }

        // GET: Test
        public async Task<IActionResult> Index()
        {
            var dhbwinContext = _context.Bets.Include(b => b.UidFk2Navigation);
            return View(await dhbwinContext.ToListAsync());
        }

        // GET: Test/Details/5
        public async Task<IActionResult> Details(string id)
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

        // GET: Test/Create
        public IActionResult Create()
        {
            ViewData["UidFk2"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: Test/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Bind("BetId,UidFk2,Title,ExpPoints,Reward,Description,CreationDate")] Bet bet)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bet);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["UidFk2"] = new SelectList(_context.Users, "Id", "Id", bet.UidFk2);
            return View(bet);
        }

        // GET: Test/Edit/5
        public async Task<IActionResult> Edit(string id)
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

            ViewData["UidFk2"] = new SelectList(_context.Users, "Id", "Id", bet.UidFk2);
            return View(bet);
        }

        // POST: Test/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id,
            [Bind("BetId,UidFk2,Title,ExpPoints,Reward,Description,CreationDate")] Bet bet)
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

            ViewData["UidFk2"] = new SelectList(_context.Users, "Id", "Id", bet.UidFk2);
            return View(bet);
        }

        // GET: Test/Delete/5
        public async Task<IActionResult> Delete(string id)
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

        // POST: Test/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
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

        private bool BetExists(string id)
        {
            return (_context.Bets?.Any(e => e.BetId == id)).GetValueOrDefault();
        }
    }
}