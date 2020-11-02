using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimesheetLaikasGroup.Models
{
    public class Division : EntityBase
    {
        public int ManagerID { get; set; }

        public string name { get; set; }

    }
}
