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
        public string EMP_ID { get; set; }

        [ForeignKey(nameof(EMP_ID))]
        public Employee Employee { get; set; }

        [NotMapped]
        public List<SelectListItem> Statuses { get; set; }


        public string TotalWorkTime { get; set; }

    }
}
