using System.Linq;
using System.Threading.Tasks;
using DHB_Win.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace DHB_Win.Controllers
{
    public class BetOptionController : Controller
    {
        private readonly DHBWinDbContext _context;

        public BetOptionController(DHBWinDbContext context)
        {
            _context = context;
        }

        // GET: BetOption
        public async Task<IActionResult> Index()
        {
            var dHBWinDbContext = _context.BetOptions.Include(b => b.Bet);
            return View(await dHBWinDbContext.ToListAsync());
        }

        // GET: BetOption/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.BetOptions == null)
            {
                return NotFound();
            }

            var betOption = await _context.BetOptions
                .Include(b => b.Bet)
                .FirstOrDefaultAsync(m => m.OptionsId == id);
            if (betOption == null)
            {
                return NotFound();
            }

            return View(betOption);
        }

        // GET: BetOption/Create
        public IActionResult Create()
        {
            ViewData["BetId"] = new SelectList(_context.Bets, "BetId", "BetId");
            return View();
        }

        // POST: BetOption/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Bind("OptionsId,BetId,Title,Descpription,QuoteValue")] BetOptionController betOptionController)
        {
            if (ModelState.IsValid)
            {
                _context.Add(betOptionController);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["BetId"] = new SelectList(_context.Bets, "BetId", "BetId", betOptionController.BetId);
            return View(betOptionController);
        }

        // GET: BetOption/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.BetOptions == null)
            {
                return NotFound();
            }

            var betOption = await _context.BetOptions.FindAsync(id);
            if (betOption == null)
            {
                return NotFound();
            }

            ViewData["BetId"] = new SelectList(_context.Bets, "BetId", "BetId", betOption.BetId);
            return View(betOption);
        }

        // POST: BetOption/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,
            [Bind("OptionsId,BetId,Title,Descpription,QuoteValue")] BetOptionController betOptionController)
        {
            if (id != betOptionController.OptionsId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(betOptionController);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BetOptionExists(betOptionController.OptionsId))
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

            ViewData["BetId"] = new SelectList(_context.Bets, "BetId", "BetId", betOptionController.BetId);
            return View(betOptionController);
        }

        // GET: BetOption/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.BetOptions == null)
            {
                return NotFound();
            }

            var betOption = await _context.BetOptions
                .Include(b => b.Bet)
                .FirstOrDefaultAsync(m => m.OptionsId == id);
            if (betOption == null)
            {
                return NotFound();
            }

            return View(betOption);
        }

        // POST: BetOption/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.BetOptions == null)
            {
                return Problem("Entity set 'DHBWinDbContext.BetOptions'  is null.");
            }

            var betOption = await _context.BetOptions.FindAsync(id);
            if (betOption != null)
            {
                _context.BetOptions.Remove(betOption);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BetOptionExists(int id)
        {
            return (_context.BetOptions?.Any(e => e.OptionsId == id)).GetValueOrDefault();
        }
    }
}