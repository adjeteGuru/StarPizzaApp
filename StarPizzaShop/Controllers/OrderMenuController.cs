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
    public class OrderMenuController : Controller
    {
        private readonly StarPizzaContext _context;

        public OrderMenuController(StarPizzaContext context)
        {
            _context = context;
        }

        // GET: OrderMenu
        public async Task<IActionResult> Index()
        {
            var starPizzaContext = _context.OrderMenus
                .Include(o => o.Drink)
                .Include(o => o.Menu)
                .Include(o => o.Order);

            return View(await starPizzaContext.ToListAsync());
        }

        // GET: OrderMenu/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderMenus = await _context.OrderMenus
                .Include(o => o.Drink)
                .Include(o => o.Menu)
                .Include(o => o.Order)
                .FirstOrDefaultAsync(m => m.OrderId == id);
            if (orderMenus == null)
            {
                return NotFound();
            }

            return View(orderMenus);
        }

        // GET: OrderMenu/Create
        public IActionResult Create()
        {
            ViewData["DrinkId"] = new SelectList(_context.Drinks, "Id", "Name");
            ViewData["MenuId"] = new SelectList(_context.Menus, "Id", "Name");
            ViewData["OrderId"] = new SelectList(_context.Orders, "Id", "Id");
            return View();
        }

        // POST: OrderMenu/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrderId,MenuId,DrinkId")] OrderMenus orderMenus)
        {
            if (ModelState.IsValid)
            {
                _context.Add(orderMenus);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DrinkId"] = new SelectList(_context.Drinks, "Id", "Name", orderMenus.DrinkId);
            ViewData["MenuId"] = new SelectList(_context.Menus, "Id", "Name", orderMenus.MenuId);
            ViewData["OrderId"] = new SelectList(_context.Orders, "Id", "Id", orderMenus.OrderId);
            return View(orderMenus);
        }

        // GET: OrderMenu/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderMenus = await _context.OrderMenus.FindAsync(id);
            if (orderMenus == null)
            {
                return NotFound();
            }
            ViewData["DrinkId"] = new SelectList(_context.Drinks, "Id", "Name", orderMenus.DrinkId);
            ViewData["MenuId"] = new SelectList(_context.Menus, "Id", "Name", orderMenus.MenuId);
            ViewData["OrderId"] = new SelectList(_context.Orders, "Id", "Id", orderMenus.OrderId);
            return View(orderMenus);
        }

        // POST: OrderMenu/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OrderId,MenuId,DrinkId")] OrderMenus orderMenus)
        {
            if (id != orderMenus.OrderId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(orderMenus);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderMenusExists(orderMenus.OrderId))
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
            ViewData["DrinkId"] = new SelectList(_context.Drinks, "Id", "Name", orderMenus.DrinkId);
            ViewData["MenuId"] = new SelectList(_context.Menus, "Id", "Name", orderMenus.MenuId);
            ViewData["OrderId"] = new SelectList(_context.Orders, "Id", "Id", orderMenus.OrderId);
            return View(orderMenus);
        }

        // GET: OrderMenu/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderMenus = await _context.OrderMenus
                .Include(o => o.Drink)
                .Include(o => o.Menu)
                .Include(o => o.Order)
                .FirstOrDefaultAsync(m => m.OrderId == id);
            if (orderMenus == null)
            {
                return NotFound();
            }

            return View(orderMenus);
        }

        // POST: OrderMenu/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var orderMenus = await _context.OrderMenus.FindAsync(id);
            _context.OrderMenus.Remove(orderMenus);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderMenusExists(int id)
        {
            return _context.OrderMenus.Any(e => e.OrderId == id);
        }
    }
}
