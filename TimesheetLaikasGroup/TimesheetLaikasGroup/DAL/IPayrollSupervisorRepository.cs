using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimesheetLaikasGroup.Models;

namespace TimesheetLaikasGroup.DAL
{
    public interface IPayrollSupervisorRepository : IDisposable
    {
        IEnumerable<PayrollSupervisor> GetPayrollSupervisors();
        PayrollSupervisor GetPayrollSupervisorByID(int payrollSupervisorId);
        void InsertPayrollSupervisor(PayrollSupervisor payrollSupervisor);
        void DeletePayrollSupervisor(int payrollSupervisorID);
        void UpdatePayrollSupervisor(PayrollSupervisor payrollSupervisor);
        void Save();
    }
}
