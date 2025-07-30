using System.ComponentModel.DataAnnotations.Schema;

namespace BuildSmart.API.Models
{
        public class Timesheet
        {
            public int TimesheetId { get; set; }
            public DateTime WorkDate { get; set; }
            [Column(TypeName = "decimal(18,2)")]
            public decimal HoursWorked { get; set; }
            public string? Notes { get; set; }

            // Foreign Keys
            public int EmployeeId { get; set; }
            public Employee Employee { get; set; }

            public int ProjectId { get; set; }
            public Project Project { get; set; }

        }
}
