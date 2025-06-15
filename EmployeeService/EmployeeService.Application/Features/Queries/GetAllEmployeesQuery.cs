using EmployeeService.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeService.Application.Features.Queries
{
    public record GetAllEmployeesQuery() : IRequest<IEnumerable<EmployeeDto>>;
    public record GetEmployeeByIdQuery(int Id) : IRequest<EmployeeDto?>;
}
