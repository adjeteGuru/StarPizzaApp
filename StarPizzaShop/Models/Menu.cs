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
        public float Price { get; set; }

        public int PackIncId { get; set; }
        public PackInc PackInc { get; set; }

        public ICollection<OrderMenus> OrderMenus { get; set; }



        //public List<OrderMenus> OrderMenus { get; set; } = new List<OrderMenus>();

    }
}
