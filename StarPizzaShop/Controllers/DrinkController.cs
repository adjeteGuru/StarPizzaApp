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
        private readonly StarPizzaContext _context;
        public DrinkController(StarPizzaContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.Drinks.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var drink = await _context.Drinks.FirstOrDefaultAsync(x => x.Id == id);

            if (drink == null)
            {
                return NotFound();
            }

            return View(drink);

        }
    }
}