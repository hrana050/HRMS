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
    public class EmployeeHandlers :
     IRequestHandler<CreateEmployeeCommand, int>,
     IRequestHandler<UpdateEmployeeCommand, bool>,
     IRequestHandler<DeleteEmployeeCommand, bool>,
     IRequestHandler<GetAllEmployeesQuery, IEnumerable<EmployeeDto>>,
     IRequestHandler<GetEmployeeByIdQuery, EmployeeDto?>
    {
        private readonly EmployeeDbContext _context;
        private readonly IMapper _mapper;

        public EmployeeHandlers(EmployeeDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<int> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = new Employee
            {
                first_name = request.EmployeeDto.emp_first_name,
                last_name = request.EmployeeDto.emp_last_name,
                email = request.EmployeeDto.emp_email,
                joining_date = request.EmployeeDto.emp_joining_date,
                salary = request.EmployeeDto.emp_salary,
                DepartmentId = request.EmployeeDto.DepartmentId,
                EmployeeType = request.EmployeeDto.EmployeeType,
                Skills = await _context.Skills.Where(s => request.EmployeeDto.SkillIds.Contains(s.Id)).ToListAsync()
            };

            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
            return employee.Id;
        }

        public async Task<bool> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = await _context.Employees.Include(e => e.Skills).FirstOrDefaultAsync(e => e.Id == request.EmployeeDto.Id);
            if (employee == null) return false;

            employee.first_name = request.EmployeeDto.emp_first_name;
            employee.last_name = request.EmployeeDto.emp_last_name;
            employee.email = request.EmployeeDto.emp_email;
            employee.joining_date = request.EmployeeDto.emp_joining_date;
            employee.salary = request.EmployeeDto.emp_salary;
            employee.DepartmentId = request.EmployeeDto.DepartmentId;
            employee.EmployeeType = request.EmployeeDto.EmployeeType;
            employee.Skills = await _context.Skills.Where(s => request.EmployeeDto.SkillIds.Contains(s.Id)).ToListAsync();

            _context.Employees.Update(employee);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = await _context.Employees.FindAsync(request.Id);
            if (employee == null) return false;

            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<EmployeeDto>> Handle(GetAllEmployeesQuery request, CancellationToken cancellationToken)
        {
            var employees = await _context.Employees.Include(e => e.Skills).Include(e => e.Department).ToListAsync();
            return _mapper.Map<IEnumerable<EmployeeDto>>(employees);
        }

        public async Task<EmployeeDto?> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
        {
            var employee = await _context.Employees.Include(e => e.Skills).Include(e => e.Department).FirstOrDefaultAsync(e => e.Id == request.Id);
            return _mapper.Map<EmployeeDto?>(employee);
        }

    }
    }
