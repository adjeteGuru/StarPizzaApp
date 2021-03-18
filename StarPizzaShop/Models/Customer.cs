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
        public string Telephone { get; set; }

        // a list of addresses and instantiated
        //public List<Address> Addresses { get; set; } = new List<Address>();
        public ICollection<Address> Addresses { get; set; }
       
        

    }
}
