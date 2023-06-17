using System;
using System.ComponentModel.DataAnnotations;

namespace Talia.Models
{
    public class StoreDetails
    {
        private string id;
        [Required(AllowEmptyStrings = true)]
        public string StoreId
        {
            get => string.IsNullOrEmpty(id) == true ? Guid.NewGuid().ToString() : id;
            set => id = value;
        }

        [Required(AllowEmptyStrings = false)]
        public string StoreName { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string StoreAddress { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string StoreCity { get; set; }

        [Required(AllowEmptyStrings = false)]
        public int StorePostal { get; set; }

        [Required(AllowEmptyStrings = false)]
        public int Phone { get; set; }

        [Required(AllowEmptyStrings = false)]
        [DataType(DataType.EmailAddress)]
        public string StoreEmail { get; set; }
    }

}
