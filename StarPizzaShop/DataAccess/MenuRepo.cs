using Microsoft.EntityFrameworkCore;
using StarPizzaShop.DataAccess.Contracts;
using StarPizzaShop.Database;
using StarPizzaShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarPizzaShop.DataAccess
{
    public class MenuRepo : IMenuRepo
    {
        private readonly StarPizzaContext _context;

        public MenuRepo(StarPizzaContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(_context));
        }
        public void CreateMenu(Menu menu)
        {
            _context.Menus.Add(menu);
        }

        public void DeleteMenu(Menu menu)
        {
            _context.Menus.Remove(menu);
        }

        //public Menu GetMenuById(int catId, int id)
        //{
        //    var category = _context.Categories
        //        .FirstOrDefault(x => x.Id == catId);

        //    var menu = category.Menus
        //        .FirstOrDefault(x => x.Id == id);

        //    return menu;
        //}

        public Menu GetMenuById(int id)
        {
            return _context.Menus.FirstOrDefault(x => x.Id == id);
        }

        //public IEnumerable<Menu> GetMenus()
        //{
        //    return _context.Menus
        //        .Include(x=>x.Category)
        //        .ToList();
        //}

        public IEnumerable<Menu> GetMenus()
        {
            return _context.Menus
                .Include(x =>x.Category)
                .ToList();
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateMenu(Menu menu)
        {
            throw new NotImplementedException();
        }

        public bool MenuExistings(int catId)
        {
            return _context.Menus
                .Any(x => x.CategoryId == catId);
        }
    }
}
