﻿using System;
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
    public class ProgramsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProgramsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Programs
        public async Task<IActionResult> Index()
        {
            return View(await _context.Program.ToListAsync());
        }

        // GET: Programs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var program = await _context.Program
                .SingleOrDefaultAsync(m => m.ID == id);
            if (program == null)
            {
                return NotFound();
            }

            ViewBag.Program = program;

            var programWeeks = await (from w in _context.ProgramWeek
                                     where (w.ProgramID == id)
                                     select w).OrderBy(p => p.WeekSequenceNum).ToListAsync();
            ViewBag.ProgramWeeks = programWeeks;

            return View(program);
        }

        // GET: Programs/Create
        public IActionResult Create()
        {
            return View();
        }

        private void CreateProgramWeeksForProgram(int numberOfWeeks, int programID, int startingNumberOfWeeks = 1)
        {
            int i = startingNumberOfWeeks;

            for (i = startingNumberOfWeeks; i <= numberOfWeeks; i++)
            {
                ProgramWeek week = new ProgramWeek();
                week.ProgramID = programID;
                week.Title = "Week " + i;
                week.WeekSequenceNum = i;
                    
                _context.Add(week);
            }
        }

        // POST: Programs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Title,DaysPerWeek,NumberOfWeeks")] Workout_Planner.Models.Workout.Program program)
        {
            if (ModelState.IsValid)
            {
                _context.Add(program);

                await _context.SaveChangesAsync();

                CreateProgramWeeksForProgram(program.NumberOfWeeks, program.ID);

                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return View(program);
        }

        // GET: Programs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var program = await _context.Program.SingleOrDefaultAsync(m => m.ID == id);
            if (program == null)
            {
                return NotFound();
            }
            return View(program);
        }

        private void UpdateProgramWeeks(int programID, int prevNumWeeks, int newNumWeeks)
        {
            
            if(prevNumWeeks < newNumWeeks)
            {
                CreateProgramWeeksForProgram(newNumWeeks, programID, prevNumWeeks+1);
            }
            else if (prevNumWeeks > newNumWeeks)
            {
                var weekRange = (from w in _context.ProgramWeek
                                 where (w.ProgramID == programID)
                                 select w).OrderByDescending(p => p.WeekSequenceNum).Take(prevNumWeeks-newNumWeeks);
                _context.ProgramWeek.RemoveRange(weekRange);
            }
        }

        // POST: Programs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Title,DaysPerWeek,NumberOfWeeks")] Workout_Planner.Models.Workout.Program program)
        {
            if (id != program.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var prevNumWeeks =
                        (from w in _context.ProgramWeek
                         where (w.ProgramID == program.ID)
                         select w).Count();
                        // Does not work!
                        //_context.Entry(program).OriginalValues.GetValue<int>("NumberOfWeeks");
                    UpdateProgramWeeks(program.ID,
                        prevNumWeeks,
                        program.NumberOfWeeks);
                    _context.Update(program);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProgramExists(program.ID))
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
            return View(program);
        }

        // GET: Programs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var program = await _context.Program
                .SingleOrDefaultAsync(m => m.ID == id);
            if (program == null)
            {
                return NotFound();
            }

            return View(program);
        }

        // POST: Programs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var program = await _context.Program.SingleOrDefaultAsync(m => m.ID == id);
            _context.Program.Remove(program);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProgramExists(int id)
        {
            return _context.Program.Any(e => e.ID == id);
        }
    }
}
