using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimesheetLaikasGroup.Data;
using TimesheetLaikasGroup.Models;

namespace TimesheetLaikasGroup.DAL
{
    public class PayrollSupervisorRepository : IPayrollSupervisorRepository, IDisposable
    {
        private ApplicationDbContext context;

        public PayrollSupervisorRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<PayrollSupervisor> GetPayrollSupervisors()
        {
            return context.PayrollSupervisors.ToList();
        }

        public PayrollSupervisor GetPayrollSupervisorByID(int id)
        {
            return context.PayrollSupervisors.Find(id);
        }

        public void InsertPayrollSupervisor(PayrollSupervisor payrollSupervisor)
        {
            context.PayrollSupervisors.Add(payrollSupervisor);
        }

        public void DeletePayrollSupervisor(int payrollSupervisorID)
        {
            PayrollSupervisor payrollSupervisor = context.PayrollSupervisors.Find(payrollSupervisorID);
            context.PayrollSupervisors.Remove(payrollSupervisor);
        }

        public void UpdatePayrollSupervisor(PayrollSupervisor payrollSupervisor)
        {
            context.Entry(payrollSupervisor).State = EntityState.Modified;
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
