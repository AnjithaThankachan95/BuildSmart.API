using BuildSmart.API.DTOs;
using BuildSmart.API.Models;

namespace BuildSmart.API.Services.Interfaces
{
    public interface ITimesheetService
    {

         IEnumerable<Timesheet> GetAll();
         Timesheet Create(TimesheetDto dto);
    }
}
