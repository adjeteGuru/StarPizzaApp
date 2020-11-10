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
        private readonly StarPizzaContext _db;
        public PackIncController(StarPizzaContext db)
        {
            _db = db;
        }

        // GET: PackInc
        public async Task<IActionResult> Index()
        {
            return View(await _db.PackIncs.ToListAsync());
        }

        // GET: PackInc/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var packInc = await _db.PackIncs
                .FirstOrDefaultAsync(x => x.Id == id);

            if (packInc == null)
            {
                return NotFound();
            }

            return View(packInc);
        }

        // GET: PackInc/Create
        public IActionResult Create()
        {
            ViewData["PackIncId"] = new SelectList(_db.PackIncs, "Id", "Name");
            return View();
        }


        // POST: PackInc/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PackInc packInc)
        {
            if (ModelState.IsValid)
            {
                await _db.PackIncs
                   .AddAsync(packInc);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(packInc);

        }
    }
}