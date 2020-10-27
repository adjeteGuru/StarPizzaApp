using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StarPizzaShop.Models
{
    public class Telephone
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(15)]
        public string PhoneNumber { get; set; }

    }
}
