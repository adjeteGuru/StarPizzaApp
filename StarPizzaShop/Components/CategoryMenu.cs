using Microsoft.AspNetCore.Mvc;
using StarPizzaShop.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarPizzaShop.Components
{
    public class CategoryMenu : ViewComponent
    {
        private readonly ICategoryRepo _categoryRepo;
        public CategoryMenu(ICategoryRepo categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }

        public IViewComponentResult Invoke()
        {
            var categories = _categoryRepo.GetCategories()
                .OrderBy(x => x.Name);
            return View(categories);
        }
    }
}
