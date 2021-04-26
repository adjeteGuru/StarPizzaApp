using Microsoft.EntityFrameworkCore;
using StarPizzaShop.Database;
using StarPizzaShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarPizzaShop.DataAccess
{
    public class CategoryRepo : ICategoryRepo
    {
        private readonly StarPizzaContext _context;
        public CategoryRepo(StarPizzaContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(_context));
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public IEnumerable<Category> GetCategories()
        {
            return _context.Categories
                .OrderBy(x => x.Name)
                .ToList();
        }        

        public bool CategoryExistings(int id)
        {
            return _context.Categories.Any(x=>x.Id == id);
        }


        public void DeleteCategory(Category category)
        {
            _context.Categories.Remove(category);
        }

        public Category GetCategoryById(int id)
        {
            var category = _context.Categories.FirstOrDefault(x=>x.Id == id);
            return category;
        }

       
        public void UpdateCategory(Category category)
        {
            throw new NotImplementedException();
        }

        public void CreateCategory(Category category)
        {
            _context.Categories.Add(category);
        }



        //public IEnumerable<Menu> GetMenusForCategory(int catId)
        //{
        //    return _context.Menus
        //        .Where(x => x.CategoryId == catId)
        //        .ToList();
        //}

        //public Menu GetMenuForCategory(int catId, int menuId)
        //{
        //    return _context.Menus
        //        .Where(x => x.CategoryId == catId && x.Id == menuId)
        //        .FirstOrDefault();
        //}

        //public Category GetCategoryById(int id, bool includeMenu)
        //{
        //    if (includeMenu)
        //    {
        //        return _context.Categories
        //            .Include(x => x.Menus)
        //            .Where(x => x.Id == id)
        //            .FirstOrDefault();
        //    }

        //return _context.Categories
        //    .Where(x => x.Id == id)
        //    .FirstOrDefault();
        //  }


        //public void CreateMenuForCategory(int catId, Menu menu)
        //{
        //    var category = GetCategoryById(catId, false);

        //    category.Menus.Add(menu);
        //}
    }
}
