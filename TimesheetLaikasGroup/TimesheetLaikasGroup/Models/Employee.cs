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
    [Table("Employee", Schema = "College" )]
    public class Employee : IdentityUser
    {

        public Employee() : base() { }
       

        [PersonalData]
        [DisplayName("First Name")]
        public String EMP_FNAME { get; set; }

        [PersonalData]
        [DisplayName("Last Name")]
        public String EMP_LNAME { get; set; }

        [DisplayName("Wage")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:c}")]
        public Double Wage { get; set; }

        public Boolean IsExempt { get; set; }

        [NotMapped]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [NotMapped]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }


    }
}
