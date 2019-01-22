using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class EmployeeNoteController : Controller
    {
        private readonly TriumphDbContext _context;

        public EmployeeNoteController(TriumphDbContext context)
        {
            _context = context;
        }

        // GET: EmployeeNote
        public async Task<IActionResult> Index()
        {
            return View(await _context.EmployeeNotes.ToListAsync());
        }

        // GET: EmployeeNote/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeNote = await _context.EmployeeNotes
                .FirstOrDefaultAsync(m => m.NoteId == id);
            if (employeeNote == null)
            {
                return NotFound();
            }

            return View(employeeNote);
        }

        // GET: EmployeeNote/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EmployeeNote/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NoteId,Title,Content,EID")] EmployeeNote employeeNote)
        {
            ViewData["EID"] = new SelectList(_context.Employees, "EmpID", "FullName");
            if (ModelState.IsValid)
            {
                _context.Add(employeeNote);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(employeeNote);
        }

        // GET: EmployeeNote/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeNote = await _context.EmployeeNotes.FindAsync(id);
            if (employeeNote == null)
            {
                return NotFound();
            }
            return View(employeeNote);
        }

        // POST: EmployeeNote/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("NoteId,Title,Content,EID")] EmployeeNote employeeNote)
        {
            if (id != employeeNote.NoteId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employeeNote);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeNoteExists(employeeNote.NoteId))
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
            return View(employeeNote);
        }

        // GET: EmployeeNote/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeNote = await _context.EmployeeNotes
                .FirstOrDefaultAsync(m => m.NoteId == id);
            if (employeeNote == null)
            {
                return NotFound();
            }

            return View(employeeNote);
        }

        // POST: EmployeeNote/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employeeNote = await _context.EmployeeNotes.FindAsync(id);
            _context.EmployeeNotes.Remove(employeeNote);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeNoteExists(int id)
        {
            return _context.EmployeeNotes.Any(e => e.NoteId == id);
        }
    }
}
