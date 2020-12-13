using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StarPizzaShop.Models
{
    public class OrderMenus
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public Orders Order { get; set; }
        public int MenuId { get; set; }
        public Menu Menu { get; set; }
        //public int DrinkId { get; set; }
        //public Drink Drink { get; set; }

        [Required(ErrorMessage = "Please choose quantity")]
        public int Quantity { get; set; }

    }
}
