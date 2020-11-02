using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimesheetLaikasGroup.DAL;
using TimesheetLaikasGroup.Models;

namespace TimesheetLaikasGroup.Controllers
{
    public class EmployeeController
    {
        IEmployeeRepository employeeRepo = null;
        public EmployeeController(IEmployeeRepository empRepo)
        {
            employeeRepo = empRepo;
        }

        public ActionResult SaveEmployee(Employee employee)
        {
            if (ModelState.IsValid)
            {
                if (string.IsNullOrEmpty(employee.Id.ToString()))
                {
                    employeeRepo.InsertEmployee(employee);
                }
                else
                {
                    employee = employeeRepo.UpdateEmployee(employee);
                }
            }
            return View("Create");
        }
    }

}
