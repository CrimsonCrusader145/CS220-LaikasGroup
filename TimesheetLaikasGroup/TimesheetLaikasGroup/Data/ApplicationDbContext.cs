using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TimesheetLaikasGroup.Models;

namespace TimesheetLaikasGroup.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public ApplicationDbContext()
        {
        }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Division> Divisions { get; set; }
        public DbSet<Timesheet> Timesheet { get; set; }
        public DbSet<Manager> Manager { get; set; }
        public DbSet<PayrollSupervisor> PayrollSupervisor { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().ToTable("Employee");
            modelBuilder.Entity<Division>().ToTable("Division");
            modelBuilder.Entity<Timesheet>().ToTable("Timesheet");
            modelBuilder.Entity<Manager>().ToTable("Manager");
            modelBuilder.Entity<PayrollSupervisor>().ToTable("PayrollSupervisor");
        }

       // public DbSet<TimesheetLaikasGroup.Models.Timesheet> Timesheet { get; set; }
       // public DbSet<TimesheetLaikasGroup.Models.Employee> Employee { get; set; }
    }
}
