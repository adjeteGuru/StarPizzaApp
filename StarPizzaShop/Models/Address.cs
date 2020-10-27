using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StarPizzaShop.Models
{
    public class Address
    {
        public int Id { get; set; }
        public string BuildingDetails { get; set; }

        [Required]
        [MaxLength(10)]
        public string HouseNo { get; set; }

        [Required]
        [MaxLength(50)]
        public string Street { get; set; }

        [Required]
        [MaxLength(15)]
        public string City { get; set; }
        public string County { get; set; }

        [Required]
        [MaxLength(10)]
        public string Postcode { get; set; }

    }
}
