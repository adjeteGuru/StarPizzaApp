using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StarPizzaShop.Models
{
    public class Menu
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        //public List<PackInc> PackIncs { get; set; } = new List<PackInc>();

        //public List<OrderMenus> OrderMenus { get; set; } = new List<OrderMenus>();
        public ICollection<OrderMenus> OrderMenus { get; set; }

    }
}
