using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StarPizzaShop.DataAccess;
using StarPizzaShop.Models;
using System;

namespace StarPizzaShop.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepo _categoryRepo;

        public CategoryController(ICategoryRepo categoryRepo)
        {
            _categoryRepo = categoryRepo ?? throw new ArgumentNullException(nameof(_categoryRepo));
        }

        // GET: Category
        public ActionResult Index()
        {
            var category = _categoryRepo.GetCategories();

            return View(category);
        }

        // GET: Category/Details/5

        public IActionResult Details(int id)
        {
            var category = _categoryRepo.GetCategoryById(id);

            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // GET: Category/Create  

        public IActionResult Create()
        {
            return View();
        }

        // POST: Category/Create
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name")] Category category)
        {
            if (ModelState.IsValid)
            {
                _categoryRepo.CreateCategory(category);

                _categoryRepo.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        [Authorize]
        // GET: Category/Delete/5
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var category = _categoryRepo.GetCategoryById(id);

            if (category == null)
            {
                return NotFound();
            }

            _categoryRepo.DeleteCategory(category);

            _categoryRepo.SaveChanges();


            return RedirectToAction(nameof(Index));
        }

    }
}
