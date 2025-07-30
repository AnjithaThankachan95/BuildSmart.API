using BuildSmart.API.Data;
using BuildSmart.API.DTOs;
using BuildSmart.API.Models;
using BuildSmart.API.Services.Interfaces;

namespace BuildSmart.API.Services
{
    public class ProjectService : IProjectService
    {
        private readonly AppDbContext _context;

        public ProjectService(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<ProjectDto> GetAll()
        {
            return _context.Projects
                .Select(p => new ProjectDto
                {
                    ProjectId = p.ProjectId,
                    ProjectName = p.Name,
                    StartDate = p.StartDate,
                    EndDate = p.EndDate,
                    Budget = p.Budget,
                    Status = p.Status
                }).ToList();
        }

        public ProjectDto? GetById(int id)
        {
            var project = _context.Projects.Find(id);
            if (project == null) return null;

            return new ProjectDto
            {
                ProjectId = project.ProjectId,
                ProjectName = project.Name,
                StartDate = project.StartDate,
                EndDate = project.EndDate,
                Budget = project.Budget,
                Status = project.Status
            };
        }

        public ProjectDto Create(ProjectDto dto)
        {
            var project = new Project
            {
                Name = dto.ProjectName,
                StartDate = dto.StartDate,
                EndDate = dto.EndDate,
                Budget = dto.Budget,
                Status = dto.Status
            };

            _context.Projects.Add(project);
            _context.SaveChanges();

            dto.ProjectId = project.ProjectId;
            return dto;
        }

        public ProjectDto? Update(int id, ProjectDto dto)
        {
            var project = _context.Projects.Find(id);
            if (project == null) return null;

            project.Name = dto.ProjectName;
            project.StartDate = dto.StartDate;
            project.EndDate = dto.EndDate;
            project.Budget = dto.Budget;
            project.Status = dto.Status;

            _context.SaveChanges();

            return dto;
        }

        public bool Delete(int id)
        {
            var project = _context.Projects.Find(id);
            if (project == null) return false;

            _context.Projects.Remove(project);
            _context.SaveChanges();
            return true;
        }
    }
}
