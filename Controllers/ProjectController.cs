using BuildSmart.API.DTOs;
using BuildSmart.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BuildSmart.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;

        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        // GET: /project
        [HttpGet]
        public IActionResult Get()
        {
            var projects = _projectService.GetAll();
            return Ok(projects);
        }

        // GET: /project/{id}
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var project = _projectService.GetById(id);
            if (project == null)
                return NotFound();

            return Ok(project);
        }

        // POST: /project
        [HttpPost]
        public IActionResult Create([FromBody] ProjectDto dto)
        {
            var created = _projectService.Create(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.ProjectId }, created);
        }

        // PUT: /project/{id}
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] ProjectDto dto)
        {
            var updated = _projectService.Update(id, dto);
            if (updated == null)
                return NotFound();

            return Ok(updated);
        }

        // DELETE: /project/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var deleted = _projectService.Delete(id);
            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }
}
