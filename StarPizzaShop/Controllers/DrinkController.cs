using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StarPizzaShop.Database;

namespace StarPizzaShop.Controllers
{
    public class DrinkController : Controller
    {
        private readonly StarPizzaContext _db;
        public DrinkController(StarPizzaContext db)
        {
            _db = db;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _db.Drinks.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var drink = await _db.Drinks.FirstOrDefaultAsync(x => x.Id == id);

            if (drink == null)
            {
                return NotFound();
            }

            return View(drink);

        }

    }
}