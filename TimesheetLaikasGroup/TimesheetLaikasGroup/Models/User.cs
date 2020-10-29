using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace TimesheetLaikasGroup.Models
{
    public class User : IdentityUser
    {
        public User() : base() { }

        [PersonalData]
        [DisplayName("First Name")]
        public String USR_FNAME { get; set; }

        [PersonalData]
        [DisplayName("Last Name")]
        public String USR_LNAME { get; set; }

        [PersonalData]
        [DisplayName("Phone Number")]
        public String USR_PHONE { get; set; }

        [PersonalData]
        [DisplayName("Address")]
        public String ADDRESS { get; set; }

        [NotMapped]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [NotMapped]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public string RoleId { get; set; }

        [ForeignKey(nameof(RoleId))]
        public Roles Roles
        {
            get; set;
        }


    }
}
