using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace TimesheetLaikasGroup.Models
{
    public class Roles : IdentityRole
    {
        public Roles() : base() { }

        public Roles(string roleName) : base(roleName) { }
    }

    public class RoleListViewModel
    {
        public string Id { get; set; }

        [DisplayName("Role Name")]
        public string RoleName { get; set; }

    }

    public class RoleViewModel
    {
        public string Id { get; set; }

        [DisplayName("Role Name")]
        public string RoleName { get; set; }
    }

    public class RoleEdit
    {
        public Roles Role { get; set; }
        public IEnumerable<User> Members { get; set; }
        public IEnumerable<User> NonMembers { get; set; }
    }

    public class RoleModification
    {
        [Required]
        public string RoleName { get; set; }

        public string RoleId { get; set; }

        public string[] AddIds { get; set; }

        public string[] DeleteIds { get; set; }
    }
}