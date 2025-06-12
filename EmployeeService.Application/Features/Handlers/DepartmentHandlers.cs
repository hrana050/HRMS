using AutoMapper;
using EmployeeService.Application.DTOs;
using EmployeeService.Application.Features.Commands;
using EmployeeService.Application.Features.Queries;
using EmployeeService.Domain.Entities;
using EmployeeService.Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeService.Application.Features.Handlers
{
    public class DepartmentHandlers :
        IRequestHandler<CreateDepartmentCommand, int>,
        IRequestHandler<GetAllDepartmentsQuery, IEnumerable<DepartmentDto>>
    {
        private readonly EmployeeDbContext _context;
        private readonly IMapper _mapper;

        public DepartmentHandlers(EmployeeDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateDepartmentCommand request, CancellationToken cancellationToken)
        {
            var dept = new Department { department_name = request.DepartmentName };
            _context.Departments.Add(dept);
            await _context.SaveChangesAsync();
            return dept.Id;
        }

        public async Task<IEnumerable<DepartmentDto>> Handle(GetAllDepartmentsQuery request, CancellationToken cancellationToken)
        {
            var depts = await _context.Departments.ToListAsync();
            return _mapper.Map<IEnumerable<DepartmentDto>>(depts);
        }
    }
}
