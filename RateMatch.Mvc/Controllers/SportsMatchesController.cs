﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RateMatch.Mvc.Data;
using RateMatch.Mvc.Data.IdentityEntities;
using RateMatch.Mvc.Models.SportsMatches;
using RateMatch.Mvc.Services;

namespace RateMatch.Mvc.Controllers
{
    public class SportsMatchesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly MatchService _matchService;



        public SportsMatchesController(ApplicationDbContext context,
            UserManager<ApplicationUser> userManager
,
            MatchService matchService
            )
        {
            _context = context;
            _userManager = userManager;
            _matchService = matchService;
        }

        // GET: SportsMatches
        public async Task<IActionResult> Index()
        {
              return View(await _matchService.GetAllAsync());
        }

        // GET: SportsMatches/Details/5
        public async Task<IActionResult> Details(int? id,string? slug)
        {
            if (id == null || _context.SportsMatches == null)
            {
                return NotFound();
            }

            var sportsMatch = await _matchService.SingleAsync(id.Value);
            if (sportsMatch == null)
            {
                return NotFound();
            }
            SportsMatchDetailsViewModel viewModel = new SportsMatchDetailsViewModel()
            {
                Item = sportsMatch
            
            };
            if(HttpContext.User.Identity != null && HttpContext.User.Identity.IsAuthenticated)
            {
                viewModel.IsLoggedIn = true;

            }
            ViewData["Title"] = sportsMatch.MatchName + " ("+sportsMatch.Competition.Sport.Name + ")";
            return View(viewModel);
        }

        // GET: SportsMatches/Create
        [Authorize]
        public IActionResult Create()
        {
            ViewData["Title"] = "Submit new Match";
            return View();
        }

        // POST: SportsMatches/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MatchName,MatchResult,Sport,CompetitionId,PlayedAt")] SportsMatchDto form)
        {
            SportsMatch sportsMatch = new SportsMatch();
            if (ModelState.IsValid)
            {
                Competition? competition = _context.Competitions
                        .Where(x => x.Id == form.CompetitionId)
                        .Include(x => x.Sport).FirstOrDefault();
                if (competition != null)
                {
                    sportsMatch.MatchName = form.MatchName.Trim();
                    sportsMatch.Slug = form.MatchName;
                    sportsMatch.MatchResult = form.MatchResult.Trim();
                    sportsMatch.CompetitionId = competition.Id;
                    // parse as utc date time //
                    sportsMatch.PlayedAt = DateTimeOffset.Parse(form.PlayedAt).UtcDateTime;

                    string slug = new Slugify.SlugHelper().GenerateSlug(
                       String.Format("{0} {1} {2}",
                       competition.Sport.Name,
                       competition.Name,
                       sportsMatch.MatchName
                       )
                    );
                    sportsMatch.Slug = slug;
                    _context.Add(sportsMatch);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                TempData["Error"] = "Competition ID isn't assigned or the competition doesn't exist.";
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

            var sportsMatch = await _matchService.SingleAsync(id.Value);
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
