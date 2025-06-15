using EmployeeService.Application.Features.Commands;
using EmployeeService.Application.Features.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DepartmentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("create-department")]
        public async Task<IActionResult> Create(string name)
        {
         
            var id = await _mediator.Send(new CreateDepartmentCommand(name));
            return Ok(id);
        }

        [HttpGet("getall-department")]
        public async Task<IActionResult> GetAll()
        {
            var list = await _mediator.Send(new GetAllDepartmentsQuery());
            return Ok(list);
        }
    }
}
