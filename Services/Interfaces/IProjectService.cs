using BuildSmart.API.DTOs;

namespace BuildSmart.API.Services.Interfaces
{
    public interface IProjectService
    {
        IEnumerable<ProjectDto> GetAll();
        ProjectDto? GetById(int id);
        ProjectDto Create(ProjectDto dto);
        ProjectDto? Update(int id, ProjectDto dto);
        bool Delete(int id);
    }
}
