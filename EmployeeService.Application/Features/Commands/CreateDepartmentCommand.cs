using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeService.Application.Features.Commands
{
    public record CreateDepartmentCommand(string DepartmentName) : IRequest<int>;
}
