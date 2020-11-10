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
    public class OrderController : Controller
    {
        private readonly StarPizzaContext _db;

        public OrderController(StarPizzaContext db)
        {
            _db = db;
        }

        // GET: Order
        public async Task<IActionResult> Index()
        {
            var starPizzaContext = _db.Orders.Include(o => o.Customer);
            return View(await starPizzaContext.ToListAsync());
        }

        // GET: Order/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orders = await _db.Orders
                .Include(o => o.Customer)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (orders == null)
            {
                return NotFound();
            }

            return View(orders);
        }

        // GET: Order/Create
        public IActionResult Create()
        {
            ViewData["CustomerId"] = new SelectList(_db.Customers, "Id", "FullName");
            return View();
        }

        // POST: Order/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DateCreated,Quantity,CustomerId,EstimateTime,SpecialNote,Alergy,Status")] Orders orders)
        {
            if (ModelState.IsValid)
            {
                _db.Add(orders);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomerId"] = new SelectList(_db.Customers, "Id", "FullName", orders.CustomerId);
            return View(orders);
        }

        // GET: Order/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orders = await _db.Orders.FindAsync(id);
            if (orders == null)
            {
                return NotFound();
            }
            ViewData["CustomerId"] = new SelectList(_db.Customers, "Id", "FullName", orders.CustomerId);
            return View(orders);
        }

        // POST: Order/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DateCreated,Quantity,CustomerId,EstimateTime,SpecialNote,Alergy,Status")] Orders orders)
        {
            if (id != orders.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _db.Update(orders);
                    await _db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrdersExists(orders.Id))
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
            ViewData["CustomerId"] = new SelectList(_db.Customers, "Id", "FullName", orders.CustomerId);
            return View(orders);
        }

        // GET: Order/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orders = await _db.Orders
                .Include(o => o.Customer)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (orders == null)
            {
                return NotFound();
            }

            return View(orders);
        }

        // POST: Order/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var orders = await _db.Orders.FindAsync(id);
            _db.Orders.Remove(orders);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrdersExists(int id)
        {
            return _db.Orders.Any(e => e.Id == id);
        }
    }
}
