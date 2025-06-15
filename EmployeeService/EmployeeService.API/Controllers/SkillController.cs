using EmployeeService.Application.Features.Commands;
using EmployeeService.Application.Features.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillController : ControllerBase
    {
        private readonly IMediator _mediator;
        public SkillController(IMediator mediator) => _mediator = mediator;

        [HttpPost]
        [Route("create-skill")]
        public async Task<IActionResult> Create(string name)
        {
            var id = await _mediator.Send(new CreateSkillCommand(name));
            return Ok(id);
        }

        [HttpGet("getall-skill")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllSkillsQuery());
            return Ok(result);
        }
    }
}
