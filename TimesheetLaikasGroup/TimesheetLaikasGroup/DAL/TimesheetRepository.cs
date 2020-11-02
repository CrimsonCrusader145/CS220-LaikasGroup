﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimesheetLaikasGroup.Data;
using TimesheetLaikasGroup.Models;

namespace TimesheetLaikasGroup.DAL
{
    public class TimesheetRepository : ITimesheetRepository, IDisposable
    {
        private ApplicationDbContext context;

        public TimesheetRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<Timesheet> GetTimesheets()
        {
            return context.Timesheets.ToList();
        }

        public Timesheet GetTimesheetByID(int id)
        {
            return context.Timesheets.Find(id);
        }

        public void InsertTimesheet(Timesheet timesheet)
        {
            context.Timesheets.Add(timesheet);
        }

        public void DeleteTimesheet(int timesheetID)
        {
            Timesheet timesheet = context.Timesheets.Find(timesheetID);
            context.Timesheets.Remove(timesheet);
        }

        public void UpdateTimesheet(Timesheet timesheet)
        {
            context.Entry(timesheet).State = EntityState.Modified;
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
