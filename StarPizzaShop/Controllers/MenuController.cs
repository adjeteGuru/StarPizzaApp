using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StarPizzaShop.Database;
using StarPizzaShop.Models.ViewModels;

namespace StarPizzaShop.Controllers
{
    public class MenuController : Controller
    {
        private readonly StarPizzaContext _db;

        [BindProperty]
        public MenuViewModel MenuVM { get; set; }

        public MenuController(StarPizzaContext db)
        {
            _db = db;

            //initialise the MenuViewModel
            MenuVM = new MenuViewModel()
            {
                //assign PackInc from the db
                PackIncs = db.PackIncs.ToList(),

                //and assign Menu too
                Menu = new Models.Menu()
            };
        }
        public IActionResult Index()
        {
            var menus = _db.Menus
                .Include(x => x.PackInc);
            //.ToList();
            return View(menus);
        }

        public IActionResult Create()
        {
            return View(MenuVM);
        }
    }
}