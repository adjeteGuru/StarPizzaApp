using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StarPizzaShop.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter category name")]
        [MaxLength(50)]
        [Display(Name = "Food Type")]
        public string Name { get; set; }

        //public ICollection<Menu> Menus { get; set; }
    }
}
