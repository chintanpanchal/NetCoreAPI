using System.ComponentModel.DataAnnotations;
using System;

namespace Talia.Models
{
    public class OrderItems
    {
        private string id;
        [Required(AllowEmptyStrings = true)]
        public string OrderItemID
        {
            get => string.IsNullOrEmpty(id) == true ? Guid.NewGuid().ToString() : id;
            set => id = value;
        }
        [Required(AllowEmptyStrings = false)]
        public string ProductID { get; set; }
        public int Quantity { get; set; }
        public decimal Discount { get; set; }
    }
}
