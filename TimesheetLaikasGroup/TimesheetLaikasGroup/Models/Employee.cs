using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimesheetLaikasGroup.Models
{
    public class Employee : EntityBase
    {
       
        public int DivisionID { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public Double Wage { get; set; }
        public Boolean IsExempt { get; set; }


    }
}
