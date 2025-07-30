namespace BuildSmart.API.Models
{
    public class Project
    {
            public int ProjectId { get; set; }
            public string Name { get; set; } = string.Empty;
            public DateTime StartDate { get; set; }
            public DateTime EndDate { get; set; }
            public decimal Budget { get; set; }
            public string Status { get; set; } = string.Empty;
    }
}
