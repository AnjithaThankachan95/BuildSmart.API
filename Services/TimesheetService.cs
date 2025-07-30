using BuildSmart.API.Data;
using BuildSmart.API.DTOs;
using BuildSmart.API.Models;
using BuildSmart.API.Services.Interfaces;

namespace BuildSmart.API.Services
{
    public class TimeSheetService : ITimesheetService
    {
        private readonly AppDbContext _context;

        public TimeSheetService(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Timesheet> GetAll() => _context.Timesheets.ToList();

        public Timesheet Create(TimesheetDto dto)
        {
            var timesheet = new Timesheet
            {
                EmployeeId = dto.EmployeeId,
                WorkDate = dto.DateWorked,
                HoursWorked = dto.HoursWorked,
                ProjectId = dto.ProjectId,
               
            };
            _context.Timesheets.Add(timesheet);
            _context.SaveChanges();
            return timesheet;
        }
    }
}
