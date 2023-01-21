using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RateMatch.Mvc.Data;
using RateMatch.Mvc.Models.SportsMatches;

namespace RateMatch.Mvc.Controllers
{
    public class SportsMatchesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SportsMatchesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SportsMatches
        public async Task<IActionResult> Index()
        {
              return View(await _context.SportsMatches.ToListAsync());
        }

        // GET: SportsMatches/Details/5
        public async Task<IActionResult> Details(int? id,string? slug)
        {
            if (id == null || _context.SportsMatches == null)
            {
                return NotFound();
            }

            var sportsMatch = await _context.SportsMatches
                .Include(x=>x.Reviews)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sportsMatch == null)
            {
                return NotFound();
            }
            SportsMatchDetailsViewModel viewModel = new SportsMatchDetailsViewModel()
            {
                Item = sportsMatch
            };
            ViewData["Title"] = sportsMatch.MatchName + " ("+sportsMatch.Sport + ")";
            return View(viewModel);
        }

        // GET: SportsMatches/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SportsMatches/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MatchName,MatchResult,Sport,Competition,PlayedAt")] SportsMatchDto form)
        {
            SportsMatch sportsMatch = new SportsMatch();
            if (ModelState.IsValid)
            {
               
                sportsMatch.MatchName = form.MatchName.Trim();
                sportsMatch.Slug = form.MatchName;
                sportsMatch.MatchResult = form.MatchResult.Trim();
                sportsMatch.Competition = form.Competition.Trim();
                sportsMatch.Sport = form.Sport.Trim();
                // parse as utc date time //
                sportsMatch.PlayedAt = DateTimeOffset.Parse(form.PlayedAt).UtcDateTime;

                string slug = new Slugify.SlugHelper().GenerateSlug(
                   String.Format("{0} {1} {2}",
                   sportsMatch.Sport,
                   sportsMatch.Competition,
                   sportsMatch.MatchName
                   )
                );
                sportsMatch.Slug = slug;
               _context.Add(sportsMatch);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(sportsMatch);
        }

        // GET: SportsMatches/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.SportsMatches == null)
            {
                return NotFound();
            }

            var sportsMatch = await _context.SportsMatches.FindAsync(id);
            if (sportsMatch == null)
            {
                return NotFound();
            }
            return View(sportsMatch);
        }

        // POST: SportsMatches/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,MatchName,MatchResult,Sport,Competition,PlayedAt,CreatedAt")] SportsMatch sportsMatch)
        {
            if (id != sportsMatch.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sportsMatch);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SportsMatchExists(sportsMatch.Id))
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
            return View(sportsMatch);
        }

        // GET: SportsMatches/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.SportsMatches == null)
            {
                return NotFound();
            }

            var sportsMatch = await _context.SportsMatches
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sportsMatch == null)
            {
                return NotFound();
            }

            return View(sportsMatch);
        }

        // POST: SportsMatches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.SportsMatches == null)
            {
                return Problem("Entity set 'ApplicationDbContext.SportsMatch'  is null.");
            }
            var sportsMatch = await _context.SportsMatches.FindAsync(id);
            if (sportsMatch != null)
            {
                _context.SportsMatches.Remove(sportsMatch);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SportsMatchExists(int id)
        {
          return _context.SportsMatches.Any(e => e.Id == id);
        }
    }
}
