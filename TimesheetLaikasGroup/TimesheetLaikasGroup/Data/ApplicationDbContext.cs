﻿using System;
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
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Division> Divisions { get; set; }
        public DbSet<Timesheet> Timesheets { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<PayrollSupervisor> PayrollSupervisors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().ToTable("Employee");
            modelBuilder.Entity<Division>().ToTable("Division");
            modelBuilder.Entity<Timesheet>().ToTable("Timesheet");
            modelBuilder.Entity<Manager>().ToTable("Manager");
            modelBuilder.Entity<PayrollSupervisor>().ToTable("PayrollSupervisor");
        }
    }
}
