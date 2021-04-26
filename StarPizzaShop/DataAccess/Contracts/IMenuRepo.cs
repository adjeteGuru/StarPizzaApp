using StarPizzaShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarPizzaShop.DataAccess.Contracts
{
    public interface IMenuRepo
    {
        void CreateMenu(Menu menu);
        void DeleteMenu(Menu menu);
         Menu GetMenuById(int id);
        IEnumerable<Menu> GetMenus();
        bool SaveChanges();
        void UpdateMenu(Menu menu);

        bool MenuExistings(int id);
    }
}
