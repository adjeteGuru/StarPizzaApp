using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
        public IActionResult Index()
        {
            return View(_context.Drinks.ToList());
        }
    }
}