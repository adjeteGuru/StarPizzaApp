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

        //public int PackIncId { get; set; }
        //public PackInc PackInc { get; set; }
        [MaxLength(100)]
        [Display(Name = "Special Note!")]
        public string Note { get; set; }

        [Required(ErrorMessage = "Please choose profile image")]
        public string ImagePath { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public ICollection<OrderMenus> OrderMenus { get; set; }



        //public List<OrderMenus> OrderMenus { get; set; } = new List<OrderMenus>();

    }
}
