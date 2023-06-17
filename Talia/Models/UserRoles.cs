using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Talia.Models
{
    public enum Role
    {
        Admin,
        Executive,
        Preparateur,
        Comptable
    }
    public class UserRoles
    {
        [Required(AllowEmptyStrings = false)]
        public string UserID { get; set; }
        public string RoleID { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string RoleName { get; set; }
    }
}
