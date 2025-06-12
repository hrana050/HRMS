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
    public class SkillsHandlers :
        IRequestHandler<CreateSkillCommand, int>,
        IRequestHandler<GetAllSkillsQuery, IEnumerable<SkillDto>>
    {
        private readonly EmployeeDbContext _context;
        private readonly IMapper _mapper;

        public SkillsHandlers(EmployeeDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<int> Handle(CreateSkillCommand request, CancellationToken cancellationToken)
        {
            var skill = new Skill { skill_name = request.SkillName };
            _context.Skills.Add(skill);
            await _context.SaveChangesAsync();
            return skill.Id;
        }
        public async Task<IEnumerable<SkillDto>> Handle(GetAllSkillsQuery request, CancellationToken cancellationToken)
        {
            var depts = await _context.Skills.ToListAsync();
            return _mapper.Map<IEnumerable<SkillDto>>(depts);
        }
       
    }
}
