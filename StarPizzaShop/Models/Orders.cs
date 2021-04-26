using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StarPizzaShop.Models
{
    public enum Status
    {
        InProcessing, OnItsWay, Delivered
    }
    public class Orders
    {
        public int Id { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime OrderDate { get; set; }        
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public decimal  DeliveryCharge { get; set; }
        public int EstimateTime { get; set; }

        [MaxLength(100)]
        public string SpecialNote { get; set; }

        [MaxLength(50)]        
        [Display(Name = "Alergy to!")]
        public string Alergy { get; set; }

        public Status Status { get; set; }
        
        public ICollection<OrderMenus> OrderMenus { get; set; } = new List<OrderMenus>();


    }
}
