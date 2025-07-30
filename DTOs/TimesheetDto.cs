namespace BuildSmart.API.DTOs
{
    public class TimesheetDto
    {
            public int EmployeeId  { get; set; }
            public int ProjectId { get; set; }
            public DateTime DateWorked { get; set; }
            public int HoursWorked { get; set; }
    }
    
}
