using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using DHB_Win.Data;
using DHB_Win.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace DHB_Win.Controllers
{
    public class AchievedAchievementsController : Controller
    {
        private readonly dhbwinContext _context;

        public AchievedAchievementsController(dhbwinContext context)
        {
            _context = context;
        }

        // GET: AchievedAchievements
        public async Task<IActionResult> Index()
        {
            var dhbwinContext = _context.AchievedAchievements.Include(a => a.AchIdFkNavigation)
                .Include(a => a.UidFkNavigation);
            ViewBag.User = _context.Users.Select(x => x)
                .Where(x => x.Id == User.FindFirstValue(ClaimTypes.NameIdentifier)).ToList();
            return View(await dhbwinContext.ToListAsync());
        }

        // GET: AchievedAchievements/Details/5
        public async Task<IActionResult> Details()
        {
            if (_context.AchievedAchievements == null)
            {
                return NotFound();
            }

            return View();
        }

        // GET: AchievedAchievements/Create
        public IActionResult Create()
        {
            ViewData["AchIdFk"] = new SelectList(_context.Achievements, "AchId", "AchId");
            ViewData["UidFk"] = new SelectList(_context.Users, "Uid", "Uid");
            return View();
        }

        // POST: AchievedAchievements/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Bind("UidFk,AchIdFk,CreationDate,Aaid")]
            AchievedAchievement achievedAchievement)
        {
            if (ModelState.IsValid)
            {
                _context.Add(achievedAchievement);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["AchIdFk"] = new SelectList(_context.Achievements, "AchId", "AchId", achievedAchievement.AchIdFk);
            ViewData["UidFk"] = new SelectList(_context.Users, "Uid", "Uid", achievedAchievement.UidFk);
            return View(achievedAchievement);
        }

        // GET: AchievedAchievements/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.AchievedAchievements == null)
            {
                return NotFound();
            }

            var achievedAchievement = await _context.AchievedAchievements.FindAsync(id);
            if (achievedAchievement == null)
            {
                return NotFound();
            }

            ViewData["AchIdFk"] = new SelectList(_context.Achievements, "AchId", "AchId", achievedAchievement.AchIdFk);
            ViewData["UidFk"] = new SelectList(_context.Users, "Uid", "Uid", achievedAchievement.UidFk);
            return View(achievedAchievement);
        }

        // POST: AchievedAchievements/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,
            [Bind("UidFk,AchIdFk,CreationDate,Aaid")]
            AchievedAchievement achievedAchievement)
        {
            if (id != achievedAchievement.Aaid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(achievedAchievement);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AchievedAchievementExists(achievedAchievement.Aaid))
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

            ViewData["AchIdFk"] = new SelectList(_context.Achievements, "AchId", "AchId", achievedAchievement.AchIdFk);
            ViewData["UidFk"] = new SelectList(_context.Users, "Uid", "Uid", achievedAchievement.UidFk);
            return View(achievedAchievement);
        }

        // GET: AchievedAchievements/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.AchievedAchievements == null)
            {
                return NotFound();
            }

            var achievedAchievement = await _context.AchievedAchievements
                .Include(a => a.AchIdFkNavigation)
                .Include(a => a.UidFkNavigation)
                .FirstOrDefaultAsync(m => m.Aaid == id);
            if (achievedAchievement == null)
            {
                return NotFound();
            }

            return View(achievedAchievement);
        }

        // POST: AchievedAchievements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.AchievedAchievements == null)
            {
                return Problem("Entity set 'dhbwinContext.AchievedAchievements'  is null.");
            }

            var achievedAchievement = await _context.AchievedAchievements.FindAsync(id);
            if (achievedAchievement != null)
            {
                _context.AchievedAchievements.Remove(achievedAchievement);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AchievedAchievementExists(int id)
        {
            return (_context.AchievedAchievements?.Any(e => e.Aaid == id)).GetValueOrDefault();
        }
    }
}