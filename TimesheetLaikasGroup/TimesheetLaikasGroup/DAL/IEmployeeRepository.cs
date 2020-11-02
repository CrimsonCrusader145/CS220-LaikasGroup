using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimesheetLaikasGroup.Models;

namespace TimesheetLaikasGroup.DAL
{
    public interface IEmployeeRepository : IDisposable
    {
        IEnumerable<Employee> GetEmployees();
        Employee GetEmployeeByID(int employeeId);
        void InsertEmployee(Employee employee);
        void DeleteEmployee(int employeeID);
        void UpdateEmployee(Employee employee);
        void Save();
    }
}
