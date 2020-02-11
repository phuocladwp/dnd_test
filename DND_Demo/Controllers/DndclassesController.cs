using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DND_Demo.Models;

namespace DND_Demo.Controllers
{
    public class DndclassesController : Controller
    {
        private readonly DND_DemoContext _context;

        public DndclassesController(DND_DemoContext context)
        {
            _context = context;
        }

        // GET: Dndclasses
        public async Task<IActionResult> Index()
        {
            return View(await _context.Dndclasses.ToListAsync());
        }

        // GET: Dndclasses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dndclasses = await _context.Dndclasses
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dndclasses == null)
            {
                return NotFound();
            }

            return View(dndclasses);
        }

        // GET: Dndclasses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Dndclasses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DndclassName,DndclassDescription")] Dndclasses dndclasses)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dndclasses);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dndclasses);
        }

        // GET: Dndclasses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dndclasses = await _context.Dndclasses.FindAsync(id);
            if (dndclasses == null)
            {
                return NotFound();
            }
            return View(dndclasses);
        }

        // POST: Dndclasses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DndclassName,DndclassDescription")] Dndclasses dndclasses)
        {
            if (id != dndclasses.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dndclasses);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DndclassesExists(dndclasses.Id))
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
            return View(dndclasses);
        }

        // GET: Dndclasses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dndclasses = await _context.Dndclasses
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dndclasses == null)
            {
                return NotFound();
            }

            return View(dndclasses);
        }

        // POST: Dndclasses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dndclasses = await _context.Dndclasses.FindAsync(id);
            _context.Dndclasses.Remove(dndclasses);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DndclassesExists(int id)
        {
            return _context.Dndclasses.Any(e => e.Id == id);
        }
    }
}
