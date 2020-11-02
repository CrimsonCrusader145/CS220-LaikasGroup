using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimesheetLaikasGroup.Models;

namespace TimesheetLaikasGroup.DAL
{
    public interface IManagerRepository : IDisposable
    {
        IEnumerable<Manager> GetManagers();
        Manager GetManagerByID(int managerId);
        void InsertManager(Manager manager);
        void DeleteManager(int managerID);
        void UpdateManager(Manager manager);
        void Save();
    }
}
