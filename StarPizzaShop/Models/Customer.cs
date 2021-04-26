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

        [Required(ErrorMessage = "Please enter your name")]
        [MaxLength(150)]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Please enter contact number")]
        [MaxLength(15)]
        public string Telephone { get; set; }

        // a list of addresses and instantiated        
        public ICollection<Address> Addresses { get; set; } = new List<Address>();
       
        

    }
}
