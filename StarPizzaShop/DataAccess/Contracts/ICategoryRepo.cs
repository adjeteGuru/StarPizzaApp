using StarPizzaShop.Models;
using System.Collections.Generic;

namespace StarPizzaShop.DataAccess
{
    public interface ICategoryRepo
    {
        bool SaveChanges();

        IEnumerable<Category> GetCategories();
        Category GetCategoryById(int id);
        void CreateCategory(Category category);
        void UpdateCategory(Category category);
        void DeleteCategory(Category category);

        bool CategoryExistings(int id);
        
       


        //Category GetCategoryById(int id, bool includeMenu);

        // IEnumerable<Menu> GetMenusForCategory(int catId);

        // Menu GetMenuForCategory(int catId, int menuId);

        // void CreateMenuForCategory(int catId, Menu menu);
    }
}