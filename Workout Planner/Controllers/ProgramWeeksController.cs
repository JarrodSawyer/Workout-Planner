using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Workout_Planner.Data;
using Workout_Planner.Models.Workout;

namespace Workout_Planner.Controllers
{
    public class ProgramWeeksController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProgramWeeksController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ProgramWeeks
        public async Task<IActionResult> Index()
        {
            return View(await _context.ProgramWeek.ToListAsync());
        }

        // GET: ProgramWeeks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var programWeek = await _context.ProgramWeek
                .SingleOrDefaultAsync(m => m.ID == id);
            if (programWeek == null)
            {
                return NotFound();
            }

            return View(programWeek);
        }

        // GET: ProgramWeeks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProgramWeeks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,ProgramID,Title")] ProgramWeek programWeek)
        {
            if (ModelState.IsValid)
            {
                _context.Add(programWeek);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(programWeek);
        }

        // GET: ProgramWeeks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var programWeek = await _context.ProgramWeek.SingleOrDefaultAsync(m => m.ID == id);
            if (programWeek == null)
            {
                return NotFound();
            }
            return View(programWeek);
        }

        // POST: ProgramWeeks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,ProgramID,Title")] ProgramWeek programWeek)
        {
            if (id != programWeek.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(programWeek);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProgramWeekExists(programWeek.ID))
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
            return View(programWeek);
        }

        // GET: ProgramWeeks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var programWeek = await _context.ProgramWeek
                .SingleOrDefaultAsync(m => m.ID == id);
            if (programWeek == null)
            {
                return NotFound();
            }

            return View(programWeek);
        }

        // POST: ProgramWeeks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var programWeek = await _context.ProgramWeek.SingleOrDefaultAsync(m => m.ID == id);
            _context.ProgramWeek.Remove(programWeek);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProgramWeekExists(int id)
        {
            return _context.ProgramWeek.Any(e => e.ID == id);
        }
    }
}
