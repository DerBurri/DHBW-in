using System.Linq;
using System.Threading.Tasks;
using DHB_Win.Data;
using DHB_Win.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DHB_Win.Controllers
{
    [Authorize]
    public class AchievementController : Controller
    {
        private readonly dhbwinContext _context;

        public AchievementController(dhbwinContext context)
        {
            _context = context;
        }

        // GET: Achievement
        public async Task<IActionResult> Index()
        {
            return _context.Achievements != null
                ? View(await _context.Achievements.ToListAsync())
                : Problem("Entity set 'dhbwinContext.Achievements'  is null.");
        }

        // GET: Achievement/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Achievements == null)
            {
                return NotFound();
            }

            var achievement = await _context.Achievements
                .FirstOrDefaultAsync(m => m.AchId == id);
            if (achievement == null)
            {
                return NotFound();
            }

            return View(achievement);
        }

        // GET: Achievement/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Achievement/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Bind("AchId,Title,Description,ExpPoints,Reward")]
            Achievement achievement)
        {
            if (ModelState.IsValid)
            {
                _context.Add(achievement);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(achievement);
        }

        // GET: Achievement/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Achievements == null)
            {
                return NotFound();
            }

            var achievement = await _context.Achievements.FindAsync(id);
            if (achievement == null)
            {
                return NotFound();
            }

            return View(achievement);
        }

        // POST: Achievement/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,
            [Bind("AchId,Title,Description,ExpPoints,Reward")]
            Achievement achievement)
        {
            if (id != achievement.AchId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(achievement);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AchievementExists(achievement.AchId))
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

            return View(achievement);
        }

        // GET: Achievement/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Achievements == null)
            {
                return NotFound();
            }

            var achievement = await _context.Achievements
                .FirstOrDefaultAsync(m => m.AchId == id);
            if (achievement == null)
            {
                return NotFound();
            }

            return View(achievement);
        }

        // POST: Achievement/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Achievements == null)
            {
                return Problem("Entity set 'dhbwinContext.Achievements'  is null.");
            }

            var achievement = await _context.Achievements.FindAsync(id);
            if (achievement != null)
            {
                _context.Achievements.Remove(achievement);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AchievementExists(int id)
        {
            return (_context.Achievements?.Any(e => e.AchId == id)).GetValueOrDefault();
        }
    }
}