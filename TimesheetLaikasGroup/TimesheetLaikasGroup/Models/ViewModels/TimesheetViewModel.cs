using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace TimesheetLaikasGroup.Models.ViewModels
{
    public class TimesheetViewModel
    {
        public DateTime ClockIn { get; set; }

        public DateTime ClockOut { get; set; }

        public string Status { get; set; }

        public string UserID { get; set; }

        [ForeignKey(nameof(UserID))]
        public User User { get; set; }

        [NotMapped]
        public List<SelectListItem> Statuses { get; set; }

        public string TotalWorkTime { get; set; }
    }
}
