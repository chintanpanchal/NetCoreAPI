using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace Talia.Models
{
    public enum UserStatus
    {
        Pending,
        Active,
        LockedOut,
        Closed,
        Banned
    }
    public class UserDetails
    {
        [Required(AllowEmptyStrings = false)]
        public string Password { get; set; }
        public string Id { get { return Guid.NewGuid().ToString(); } }
        [Required(AllowEmptyStrings = false)]
        public string UserName { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Email { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string PhoneNumber { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Status { get; set; }
    }

    public class UserLogin
    {
        [Required(AllowEmptyStrings = false)]
        public string Password { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string UserName { get; set; }
    }

}
