using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TimesheetLaikasGroup.Data;
using TimesheetLaikasGroup.Models;
using TimesheetLaikasGroup.Models.ViewModels;

namespace TimesheetLaikasGroup.Controllers
{
    [Authorize]
    public class TimesheetController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;

        public TimesheetController(ApplicationDbContext context, UserManager<User> userManager)
        {
            _userManager = userManager;
            _context = context;
        }
        public async Task<IActionResult> Index(string sortOrder, string statusString)
        {
            ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["StatusFilter"] = statusString;
            var db = _context.Timesheet.Include(t => t.User);

            var timesheets = from t in _context.Timesheet
                             select t;

            if (!String.IsNullOrEmpty(statusString))
            {
                timesheets = timesheets.Where(t => t.Status.Contains(statusString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    timesheets = timesheets.OrderByDescending(t => t.User.UserName);
                    break;

                case "Date":
                    timesheets = timesheets.OrderBy(t => t.ClockIn);
                    break;

                case "date_desc":
                    timesheets = timesheets.OrderByDescending(t => t.ClockIn);
                    break;
            }

            return View(await timesheets.AsNoTracking().ToListAsync());
        }


        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var timesheet = await _context.Timesheet
                .Include(t => t.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (timesheet == null)
            {
                return NotFound();
            }

            return View(timesheet);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TimesheetViewModel model)
        {
            var statuses = new List<SelectListItem>();
            var currentUser = await _userManager.GetUserAsync(HttpContext.User);

            if (ModelState.IsValid)
            {
                Timesheet timesheet = new Timesheet();

                TimeSpan difference = model.ClockOut - model.ClockIn;

                timesheet.ClockIn = model.ClockIn;
                timesheet.ClockOut = model.ClockOut;
                timesheet.Status = "Pending";
                timesheet.UserID = currentUser.Id;
                timesheet.TotalWorkTime = string.Format("{0:0}:{1:00}", difference.TotalHours, difference.Minutes); //To Do: Need to see how to format minutes

                _context.Add(timesheet);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }


            return View(model);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            TimesheetViewModel model = new TimesheetViewModel();
            if (id == null)
            {
                return NotFound();
            }

            var timesheet = await _context.Timesheet.FindAsync(id);
            timesheet.Statuses = new List<SelectListItem>
                {
                    new SelectListItem {Value = "Approved", Text = "Approved" },
                    new SelectListItem {Value = "Rejected", Text = "Rejected" }
                };
            if (id != null)
            {
                model.Status = timesheet.Status;
                model.UserID = timesheet.UserID;
                model.ClockIn = timesheet.ClockIn;
                model.ClockOut = timesheet.ClockOut;
                model.TotalWorkTime = timesheet.TotalWorkTime;
            }
            if (timesheet == null)
            {
                return NotFound();
            }
            ViewData["UserID"] = new SelectList(_context.User, "Id", "Id", timesheet.UserID);
            return View(timesheet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, TimesheetViewModel timesheet)
        {
            if (ModelState.IsValid)
            {
                var timesheetEdit = await _context.Timesheet.FindAsync(id);

                if (timesheetEdit != null)
                {
                    timesheetEdit.Status = timesheet.Status;
                    timesheetEdit.ClockIn = timesheet.ClockIn;
                    timesheetEdit.ClockOut = timesheet.ClockOut;
                    timesheetEdit.UserID = timesheet.UserID;
                    timesheetEdit.TotalWorkTime = string.Format("{0:0}:{1:00}", (int)timesheet.ClockOut.Subtract(timesheet.ClockIn).TotalHours, timesheet.ClockOut.Subtract(timesheet.ClockIn).Minutes);
                    timesheetEdit.TotalWorkTime = timesheet.TotalWorkTime;
                }

                _context.Update(timesheetEdit);

                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            ViewData["UserID"] = new SelectList(_context.User, "Id", "Id", timesheet.UserID);

            return View(timesheet);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var timesheet = await _context.Timesheet
                .Include(t => t.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (timesheet == null)
            {
                return NotFound();
            }

            return View(timesheet);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var timesheet = await _context.Timesheet.FindAsync(id);
            _context.Timesheet.Remove(timesheet);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TimesheetExists(int id)
        {
            return _context.Timesheet.Any(e => e.Id == id);
        }
    }
}