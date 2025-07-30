namespace BuildSmart.API.DTOs
{
    public class ProjectDto
    {
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Decimal Budget { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }


    }
}
