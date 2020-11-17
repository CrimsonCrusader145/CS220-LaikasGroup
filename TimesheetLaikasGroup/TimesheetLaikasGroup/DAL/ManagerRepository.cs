using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimesheetLaikasGroup.Data;
using TimesheetLaikasGroup.Models;

namespace TimesheetLaikasGroup.DAL
{
    public class ManagerRepository : IManagerRepository, IDisposable
    {
        private ApplicationDbContext context;

        public ManagerRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<Manager> GetManagers()
        {
            return context.Manager.ToList();
        }

        public Manager GetManagerByID(int id)
        {
            return context.Manager.Find(id);
        }

        public void InsertManager(Manager manager)
        {
            context.Manager.Add(manager);
        }

        public void DeleteManager(int managerID)
        {
            Manager manager = context.Manager.Find(managerID);
            context.Manager.Remove(manager);
        }

        public void UpdateManager(Manager manager)
        {
            context.Entry(manager).State = EntityState.Modified;
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
