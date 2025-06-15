using EmployeeService.Application.DTOs;
using EmployeeService.Application.Features.Commands;
using EmployeeService.Application.Features.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeService.API.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EmployeeController(IMediator mediator) => _mediator = mediator;

        [HttpPost]
        [Route("create-employee")]
        public async Task<IActionResult> Create(CreateEmployeeDto employeeDto)
        {
          
            var result = await _mediator.Send(new CreateEmployeeCommand(employeeDto));
            return Ok(result);
        }

        [HttpPut("update-employee/{id}")]
        public async Task<IActionResult> Update(CreateEmployeeDto employeeDto)
        {
            var result = await _mediator.Send(new UpdateEmployeeCommand(employeeDto));
            return Ok(result);
        }

        [HttpDelete("delete-employee-byId/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new DeleteEmployeeCommand(id));
            return Ok(result);
        }

        [HttpGet]
        [Route("getall-employees")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllEmployeesQuery());
            return Ok(result);
        }

        [HttpGet("get-employee-byId/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _mediator.Send(new GetEmployeeByIdQuery(id));
            return Ok(result);
        }
    }
}
