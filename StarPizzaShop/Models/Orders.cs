using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        public Orders()
        {
            DeliveryCharge = 2; // Default Value £2
        }
        public int Id { get; set; }

        private DateTime? dateCreated = null;
        public DateTime DateCreated
        {
            get
            {
                return this.dateCreated.HasValue
                   ? this.dateCreated.Value
                   : DateTime.Now;
            }

            set { this.dateCreated = value; }
        }


        public int Quantity { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        [DefaultValue(2)]
        public float DeliveryCharge { get; set; }

        public int EstimateTime { get; set; }


        [MaxLength(100)]
        public string SpecialNote { get; set; }

        [MaxLength(50)]
        public string Alergy { get; set; }

        public ICollection<OrderMenus> OrderMenus { get; set; }

        //public List<OrderMenus> OrderMenus { get; set; } = new List<OrderMenus>();

        public Status Status { get; set; }

    }
}
