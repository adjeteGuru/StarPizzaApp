﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StarPizzaShop.Models
{
    public class Category
    {
        public int Id { get; set; }

        [MaxLength(50)]
        [Required(ErrorMessage = "Please enter category name")]
        public string Name { get; set; }

        public ICollection<Menu> Menus { get; set; } = new List<Menu>();
    }
}
