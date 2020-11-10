using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StarPizzaShop.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(150)]
        public string FullName { get; set; }

        [Required]
        [MaxLength(15)]
        public string Tel { get; set; }

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


        [MaxLength(20)]
        public string County { get; set; }

        [Required]
        [MaxLength(10)]
        public string Postcode { get; set; }


        public ICollection<Orders> Orders { get; set; }

        //// a list of addresses and instantiated
        //public List<Address> Addresses { get; set; } = new List<Address>();

        //// a list of telephone numbers and instantiated
        //public List<Telephone> PhoneNumbers { get; set; } = new List<Telephone>();

    }
}
