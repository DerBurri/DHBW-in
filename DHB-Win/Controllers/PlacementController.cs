using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DHB_Win.Data;
using DHB_Win.Models;

namespace DHB_Win.Controllers
{
    public class PlacementController : Controller
    {
        private readonly dhbwinContext _context;

        public PlacementController(dhbwinContext context)
        {
            _context = context;
        }

        // GET: Placement
        public async Task<IActionResult> Index()
        {
            var dhbwinContext = _context.Placements.Include(p => p.Bet).Include(p => p.BetOption).Include(p => p.User);
            return View(await dhbwinContext.ToListAsync());
        }

        // GET: Placement/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Placements == null)
            {
                return NotFound();
            }

            var placement = await _context.Placements
                .Include(p => p.Bet)
                .Include(p => p.BetOption)
                .Include(p => p.User)
                .FirstOrDefaultAsync(m => m.PlacementId == id);
            if (placement == null)
            {
                return NotFound();
            }

            return View(placement);
        }
     
        // GET: Placement/Create
        public IActionResult Create()
        {
            ViewData["BetIdFk"] = new SelectList(_context.Bets, "BetId", "Description");
            ViewData["OptionIdFk"] = new SelectList(_context.BetOptions, "OptionsId", "OptionsId");
            ViewData["UidFk"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: Placement/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PlacementId,BetIdFk,UidFk,OptionIdFk")] Placement placement)
        {
            
            if (ModelState.IsValid)
            {
                _context.Add(placement);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BetIdFk"] = new SelectList(_context.Bets, "BetId", "Description", placement.BetIdFk);
            ViewData["OptionIdFk"] = new SelectList(_context.BetOptions, "OptionsId", "OptionsId", placement.OptionIdFk);
            ViewData["UidFk"] = new SelectList(_context.Users, "Id", "Id", placement.UidFk);
            return View(placement);
        }
        

        // GET: Placement/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Placements == null)
            {
                return NotFound();
            }

            var placement = await _context.Placements.FindAsync(id);
            if (placement == null)
            {
                return NotFound();
            }
            ViewData["BetIdFk"] = new SelectList(_context.Bets, "BetId", "Description", placement.BetIdFk);
            ViewData["OptionIdFk"] = new SelectList(_context.BetOptions, "OptionsId", "OptionsId", placement.OptionIdFk);
            ViewData["UidFk"] = new SelectList(_context.Users, "Id", "Id", placement.UidFk);
            return View(placement);
        }

        // POST: Placement/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PlacementId,BetIdFk,UidFk,OptionIdFk")] Placement placement)
        {
            if (id != placement.PlacementId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(placement);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlacementExists(placement.PlacementId))
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
            ViewData["BetIdFk"] = new SelectList(_context.Bets, "BetId", "Description", placement.BetIdFk);
            ViewData["OptionIdFk"] = new SelectList(_context.BetOptions, "OptionsId", "OptionsId", placement.OptionIdFk);
            ViewData["UidFk"] = new SelectList(_context.Users, "Id", "Id", placement.UidFk);
            return View(placement);
        }

        // GET: Placement/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Placements == null)
            {
                return NotFound();
            }

            var placement = await _context.Placements
                .Include(p => p.Bet)
                .Include(p => p.BetOption)
                .Include(p => p.User)
                .FirstOrDefaultAsync(m => m.PlacementId == id);
            if (placement == null)
            {
                return NotFound();
            }

            return View(placement);
        }

        // POST: Placement/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Placements == null)
            {
                return Problem("Entity set 'dhbwinContext.Placements'  is null.");
            }
            var placement = await _context.Placements.FindAsync(id);
            if (placement != null)
            {
                _context.Placements.Remove(placement);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlacementExists(int id)
        {
          return (_context.Placements?.Any(e => e.PlacementId == id)).GetValueOrDefault();
        }
    }
}
