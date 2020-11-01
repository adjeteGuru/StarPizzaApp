using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StarPizzaShop.Database;

namespace StarPizzaShop.Controllers
{
    public class PackIncController : Controller
    {
        private readonly StarPizzaContext _context;
        public PackIncController(StarPizzaContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.PackIncs.ToListAsync());
        }
    }
}