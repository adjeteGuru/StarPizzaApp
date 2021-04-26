using Microsoft.AspNetCore.Mvc;
using StarPizzaShop.DataAccess.Contracts;
using StarPizzaShop.Models;
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
        public HomeController(IMenuRepo menuRepo)
        {
            _menuRepo = menuRepo;
        }
        public IActionResult Index()
        {
            //var homeViewModel = new HomeViewModel
            //{
            //    MenuOfTheWeek = _menuRepo.MenuExistings
            //};
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
