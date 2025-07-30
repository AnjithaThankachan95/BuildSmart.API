using System.Collections.Generic;
using BuildSmart.API.Models;
using Microsoft.EntityFrameworkCore;

namespace BuildSmart.API.Data
{
    public class AppDbContext :DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Timesheet> Timesheets { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}
