using BuildSmart.API.DTOs;
using BuildSmart.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BuildSmart.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        // GET: /employee
        [HttpGet]
        public IActionResult GetAll()
        {
            var employees = _employeeService.GetAll();
            return Ok(employees);
        }

        // GET: /employee/{id}
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var employee = _employeeService.GetById(id);
            if (employee == null)
                return NotFound();

            return Ok(employee);
        }

        // POST: /employee
        [HttpPost]
        public IActionResult Create([FromBody] EmployeeDto dto)
        {
            var created = _employeeService.Create(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.EmployeeId }, created);
        }

        // PUT: /employee/{id}
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] EmployeeDto dto)
        {
            var updated = _employeeService.Update(id, dto);
            if (updated == null)
                return NotFound();

            return Ok(updated);
        }

        // DELETE: /employee/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var deleted = _employeeService.Delete(id);
            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }
}
