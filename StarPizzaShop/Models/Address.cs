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

        [Display(Name = "Building Name")]
        public string BuildingDetails { get; set; }

        
        [MaxLength(10)]
        [Display(Name = "House No")]
        public string HouseNo { get; set; }

        [Required(ErrorMessage = "Please enter  street name")]
        [MaxLength(50)]
        public string Street { get; set; }

        [Required(ErrorMessage = "Please enter city")]
        [MaxLength(15)]
        public string City { get; set; }
        public string County { get; set; }

        [Required(ErrorMessage = "Please enter postcode")]
        [MaxLength(10)]
        public string Postcode { get; set; }

    }
}
