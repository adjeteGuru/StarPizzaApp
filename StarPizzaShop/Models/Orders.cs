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

        private float deliveryCharge = 2;

        public float GetDeliveryCharge()
        {
            return deliveryCharge;
        }

        public void SetDeliveryCharge(float value)
        {
            deliveryCharge = value;
        }

        public int EstimateTime { get; set; }


        [MaxLength(100)]
        public string SpecialNote { get; set; }

        [MaxLength(50)]
        public string Alergy { get; set; }

        public List<OrderMenus> OrderMenus { get; set; } = new List<OrderMenus>();

        public Status Status { get; set; }

    }
}
