using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimesheetLaikasGroup.Models;

namespace TimesheetLaikasGroup.DAL
{
    public interface ITimesheetRepository : IDisposable
    {
        IEnumerable<Timesheet> GetTimesheets();
        Timesheet GetTimesheetByID(int timesheetId);
        void InsertTimesheet(Timesheet timesheet);
        void DeleteTimesheet(int timesheetID);
        void UpdateTimesheet(Timesheet timesheet);
        void Save();
    }
}
