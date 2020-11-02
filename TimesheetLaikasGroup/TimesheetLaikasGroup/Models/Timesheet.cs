using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace TimesheetLaikasGroup.Models
{

    public class Timesheet : EntityBase
    {
        public DateTime ClockIn { get; set; }
        public DateTime ClockOut { get; set; }
        public string Status { get; set; }
        public string UserID { get; set; }

        [ForeignKey(nameof(UserID))]
        public User User { get; set; }

        [NotMapped]
        public List<SelectListItem> Statuses { get; } = new List<SelectListItem>
       {
            new SelectListItem {Value = "Approved", Text = "Approved" },
            new SelectListItem {Value = "Rejected", Text = "Rejected" }
       };

        public string TotalWorkTime { get; set; }

    }
}
