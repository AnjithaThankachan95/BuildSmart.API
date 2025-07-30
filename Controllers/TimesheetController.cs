using BuildSmart.API.DTOs;
using BuildSmart.API.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BuildSmart.API.Controllers
{
        [ApiController]
        [Route("[controller]")]
        public class TimesheetController : ControllerBase
        {
            private readonly ITimesheetService _timesheetService;

            public TimesheetController(ITimesheetService timesheetService)
            {
                _timesheetService = timesheetService;
            }

            [HttpGet]
            public IActionResult Get() => Ok(_timesheetService.GetAll());

            [HttpPost]
            public IActionResult Post([FromBody] TimesheetDto dto)
            {
                var result = _timesheetService.Create(dto);
                return CreatedAtAction(nameof(Get), new { id = result.TimesheetId }, result);
            }
        }
}

