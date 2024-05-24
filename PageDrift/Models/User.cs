using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace PageDrift.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required(ErrorMessage ="User Name Can not be Empty")]
        [DisplayName("User Name")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Email Can not be Empty")]
        [EmailAddress(ErrorMessage="Email is not in Correct Format")]
        public string Email { get; set; }
        [MembershipPassword]
        [Required(ErrorMessage = "Password Can not be Empty")]
        public string Password { get; set; }

        public ICollection<UserRole> UserRoles { get; set; }
       
    }
}