using StarPizzaShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarPizzaShop.ViewModels
{
    public class MenuListViewModel
    {
        public IEnumerable<Menu> Menus { get; set; }
        public string SelectedCategory { get; set; }
    }
}
