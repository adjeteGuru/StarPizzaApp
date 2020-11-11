using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StarPizzaShop.Database;
using StarPizzaShop.Models;

namespace StarPizzaShop.Controllers
{
    public class PackIncController : Controller
    {
        private readonly StarPizzaContext _context;

        public PackIncController(StarPizzaContext context)
        {
            _context = context;
        }

        // GET: PackInc
        public async Task<IActionResult> Index()
        {
            return View(await _context.PackIncs.ToListAsync());
        }

        // GET: PackInc/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var packInc = await _context.PackIncs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (packInc == null)
            {
                return NotFound();
            }

            return View(packInc);
        }

        // GET: PackInc/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PackInc/Create       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] PackInc packInc)
        {
            if (ModelState.IsValid)
            {
                _context.Add(packInc);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(packInc);
        }

        // GET: PackInc/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var packInc = await _context.PackIncs.FindAsync(id);
            if (packInc == null)
            {
                return NotFound();
            }
            return View(packInc);
        }

        // POST: PackInc/Edit/5     
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] PackInc packInc)
        {
            if (id != packInc.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(packInc);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PackIncExists(packInc.Id))
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
            return View(packInc);
        }

        // GET: PackInc/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var packInc = await _context.PackIncs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (packInc == null)
            {
                return NotFound();
            }

            return View(packInc);
        }

        // POST: PackInc/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var packInc = await _context.PackIncs.FindAsync(id);
            _context.PackIncs.Remove(packInc);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PackIncExists(int id)
        {
            return _context.PackIncs.Any(e => e.Id == id);
        }
    }
}
