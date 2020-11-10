using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarPizzaShop.Models.ViewModels
{
    public class MenuViewModel
    {
        public Menu Menu { get; set; }
        public IEnumerable<PackInc> PackIncs { get; set; }
    }
}
