using Microsoft.AspNetCore.Mvc;
using StarPizzaShop.DataAccess;
using StarPizzaShop.DataAccess.Contracts;
using StarPizzaShop.Models;
using StarPizzaShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace StarPizzaShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMenuRepo _menuRepo;
        private readonly ICategoryRepo _categoryRepo;
        public HomeController(IMenuRepo menuRepo, ICategoryRepo categoryRepo)
        {
            _menuRepo = menuRepo ?? throw new ArgumentNullException(nameof(_menuRepo));
            _categoryRepo = categoryRepo ?? throw new ArgumentNullException(nameof(_categoryRepo));
        }


        //GET: Menu/Details/5
        public IActionResult Details(int id)
        {
            var menu = _menuRepo.GetMenuById(id);

            if (menu == null)
            {
                return NotFound();
            }

            return View(menu);
        }

        // GET: Menu
        public ViewResult Index(string category)
        {
            IEnumerable<Menu> menus;
            string currentCategory;

            if (string.IsNullOrEmpty(category))
            {
                menus = _menuRepo.GetMenus()
                    .OrderBy(x => x.Id);
                currentCategory = "All menus";

            }

            else
            {
                menus = _menuRepo.GetMenus()
                    .Where(x => x.Category.Name == category)
                    .OrderBy(x => x.Id);

                currentCategory = _categoryRepo.GetCategories()
                    .FirstOrDefault(x => x.Name == category)?.Name;
            }

            return View(new MenuListViewModel
            {
                Menus = menus,
                SelectedCategory = currentCategory
            });
        }        
    }
}
