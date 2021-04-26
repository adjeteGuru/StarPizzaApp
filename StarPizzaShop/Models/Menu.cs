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

        [Required(ErrorMessage = "Please enter name")]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter price")]
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImgPathUrl { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }      
       
        public ICollection<OrderMenus> OrderMenus { get; set; } = new List<OrderMenus>();

    }
}
