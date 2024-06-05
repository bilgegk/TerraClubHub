using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using TerraClubHub.Data;
using TerraClubHub.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace TerraClubHub.Controllers
{
    public class ClubActivitiesController : Controller
    {
        private readonly ClubHubContext _context;

        public ClubActivitiesController(ClubHubContext context)
        {
            _context = context;
        }

        // GET: ClubActivities
        public async Task<IActionResult> Index()
        {
            var clubHubContext = _context.ClubActivities.Include(c => c.Club);
            return View(await clubHubContext.ToListAsync());
        }

        // GET: ClubActivities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clubActivity = await _context.ClubActivities
                .Include(c => c.Club)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (clubActivity == null)
            {
                return NotFound();
            }

            return View(clubActivity);
        }

        // GET: ClubActivities/Create
        public IActionResult Create()
        {
            ViewData["ClubId"] = new SelectList(_context.Clubs, "ID", "Name");
            return View();
        }

        // POST: ClubActivities/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Description,StartDate,EndDate,Location,Budget,CostPerPerson,NumberOfMembersParticipated,FilePath,ClubID")] ClubActivity clubActivity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(clubActivity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClubId"] = new SelectList(_context.Clubs, "ID", "Name", clubActivity.ClubID);
            return View(clubActivity);
        }

        // GET: ClubActivities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clubActivity = await _context.ClubActivities.FindAsync(id);
            if (clubActivity == null)
            {
                return NotFound();
            }
            ViewData["ClubId"] = new SelectList(_context.Clubs, "ID", "Name", clubActivity.ClubID);
            return View(clubActivity);
        }

        // POST: ClubActivities/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Description,StartDate,EndDate,Location,Budget,File,CostPerPerson,NumberOfMembersParticipated,Image,ClubId")] ClubActivity clubActivity)
        {
            if (id != clubActivity.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clubActivity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClubActivityExists(clubActivity.ID))
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
            ViewData["ClubId"] = new SelectList(_context.Clubs, "ID", "Name", clubActivity.ClubID);
            return View(clubActivity);
        }

        // GET: ClubActivities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clubActivity = await _context.ClubActivities
                .Include(c => c.Club)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (clubActivity == null)
            {
                return NotFound();
            }

            return View(clubActivity);
        }

        // POST: ClubActivities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var clubActivity = await _context.ClubActivities.FindAsync(id);
            _context.ClubActivities.Remove(clubActivity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClubActivityExists(int id)
        {
            return _context.ClubActivities.Any(e => e.ID == id);
        }
    }
}
