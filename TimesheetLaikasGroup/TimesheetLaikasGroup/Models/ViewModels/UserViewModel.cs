using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TimesheetLaikasGroup.Models.ViewModels
{
    public class UserViewModel
    {
        public string Id { get; set; }

        public string UserName { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [PersonalData]
        [DisplayName("Phone Number")]
        public String EMP_PHONE { get; set; }

        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "The new password and confirmation password do not match.")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        [PersonalData]
        [DisplayName("First Name")]
        public string EMP_FNAME { get; set; }

        [PersonalData]
        [DisplayName("Last Name")]
        public string EMP_LNAME { get; set; }
    }
}
