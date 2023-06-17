using System.ComponentModel.DataAnnotations;
using System;

namespace Talia.Models
{
    public class Orders
    {
        private string id;
        [Required(AllowEmptyStrings = true)]
        public string OrderID
        {
            get => string.IsNullOrEmpty(id) == true ? Guid.NewGuid().ToString() : id;
            set => id = value;
        }
        public string StoreID { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string UserID { get; set; }
        public short Status { get; set; }
    }
    public enum OrderStatus
    {
        Placed,
        InProgress,
        Completed
    }
}
