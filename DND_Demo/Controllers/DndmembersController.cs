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
    public class DndmembersController : Controller
    {
        private readonly DND_DemoContext _context;

        public DndmembersController(DND_DemoContext context)
        {
            _context = context;
        }

        // GET: Dndmembers
        public async Task<IActionResult> Index()
        {
            var dND_DemoContext = _context.Dndmembers.Include(d => d.Dndclass);
            return View(await dND_DemoContext.ToListAsync());
        }

        // GET: Dndmembers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dndmembers = await _context.Dndmembers
                .Include(d => d.Dndclass)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dndmembers == null)
            {
                return NotFound();
            }

            return View(dndmembers);
        }

        // GET: Dndmembers/Create
        public IActionResult Create()
        {
            ViewData["DndclassId"] = new SelectList(_context.Dndclasses, "Id", "DndclassName");
            return View();
        }

        // POST: Dndmembers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NetworkId,RealName,Dndname,EmailAddress,DndclassId,FavoriteTvseries,IsDeleted,UpdatedBy,CreatedTimestamp,LastUpdateTimestamp")] Dndmembers dndmembers)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dndmembers);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DndclassId"] = new SelectList(_context.Dndclasses, "Id", "DndclassName", dndmembers.DndclassId);
            return View(dndmembers);
        }

        // GET: Dndmembers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dndmembers = await _context.Dndmembers.FindAsync(id);
            if (dndmembers == null)
            {
                return NotFound();
            }
            ViewData["DndclassId"] = new SelectList(_context.Dndclasses, "Id", "DndclassName", dndmembers.DndclassId);
            return View(dndmembers);
        }

        // POST: Dndmembers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NetworkId,RealName,Dndname,EmailAddress,DndclassId,FavoriteTvseries,IsDeleted,UpdatedBy,CreatedTimestamp,LastUpdateTimestamp")] Dndmembers dndmembers)
        {
            if (id != dndmembers.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dndmembers);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DndmembersExists(dndmembers.Id))
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
            ViewData["DndclassId"] = new SelectList(_context.Dndclasses, "Id", "Id", dndmembers.DndclassId);
            return View(dndmembers);
        }

        // GET: Dndmembers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dndmembers = await _context.Dndmembers
                .Include(d => d.Dndclass)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dndmembers == null)
            {
                return NotFound();
            }

            return View(dndmembers);
        }

        // POST: Dndmembers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dndmembers = await _context.Dndmembers.FindAsync(id);
            _context.Dndmembers.Remove(dndmembers);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DndmembersExists(int id)
        {
            return _context.Dndmembers.Any(e => e.Id == id);
        }
    }
}
