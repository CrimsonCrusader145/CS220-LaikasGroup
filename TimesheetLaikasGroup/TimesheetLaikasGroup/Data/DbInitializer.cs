using TimesheetLaikasGroup.Models;
using System;
using System.Linq;

namespace TimesheetLaikasGroup.Data

{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();

            // Look for any employees.
            if (context.Employee.Any())
            {
                return;   // DB has been seeded
            }

            var employees = new Employee[]
            {
            new Employee{EMP_FNAME="Carson",EMP_LNAME="Alexander",Wage=8.75},

            };
            foreach (Employee e in employees)
            {
                context.Employee.Add(e);
            }
            context.SaveChanges();

            var divisions = new Division[]
            {
            new Division{ManagerID=1, name="Accounting"}

            };
            foreach (Division d in divisions)
            {
                context.Divisions.Add(d);
            }
            context.SaveChanges();

            var Timesheets = new Timesheet[]
            {

            };

        }
        //context.SaveChanges();
    }
}
