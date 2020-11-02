using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimesheetLaikasGroup.Models;

namespace TimesheetLaikasGroup.DAL
{
    public interface IDivisionRepository : IDisposable
    {
        IEnumerable<Division> GetDivisions();
        Division GetDivisionByID(int divisionId);
        void InsertDivision(Division division);
        void DeleteDivision(int divisionID);
        void UpdateDivision(Division division);
        void Save();
    }
}
