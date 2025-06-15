using AutoMapper;
using EmployeeService.Application.DTOs;
using EmployeeService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeService.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Entity to DTO
            CreateMap<Employee, EmployeeDto>()
                .ForMember(dest => dest.emp_first_name, opt => opt.MapFrom(src => src.first_name))
                .ForMember(dest => dest.emp_last_name, opt => opt.MapFrom(src => src.last_name))
                .ForMember(dest => dest.emp_email, opt => opt.MapFrom(src => src.email))
                .ForMember(dest => dest.emp_joining_date, opt => opt.MapFrom(src => src.joining_date))
                .ForMember(dest => dest.emp_salary, opt => opt.MapFrom(src => src.salary))
              //  .ForMember(dest => dest.DepartmentId, opt => opt.MapFrom(src => src.DepartmentId))
                .ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.Department.department_name))
                .ForMember(dest => dest.EmployeeType, opt => opt.MapFrom(src => src.EmployeeType))
                .ForMember(dest => dest.SkillNames, opt => opt.MapFrom(src => src.Skills.Select(s => s.skill_name).ToList()));

            // DTO to Entity
            CreateMap<EmployeeDto, Employee>()
                .ForMember(dest => dest.first_name, opt => opt.MapFrom(src => src.emp_first_name))
                .ForMember(dest => dest.last_name, opt => opt.MapFrom(src => src.emp_last_name))
                .ForMember(dest => dest.email, opt => opt.MapFrom(src => src.emp_email))
                .ForMember(dest => dest.joining_date, opt => opt.MapFrom(src => src.emp_joining_date))
                .ForMember(dest => dest.salary, opt => opt.MapFrom(src => src.emp_salary))
              //  .ForMember(dest => dest.DepartmentId, opt => opt.MapFrom(src => src.DepartmentId))
                .ForMember(dest => dest.EmployeeType, opt => opt.MapFrom(src => src.EmployeeType))
                .ForMember(dest => dest.Department, opt => opt.Ignore())
                .ForMember(dest => dest.Skills, opt => opt.Ignore());

            // Department mapping
            CreateMap<Department, DepartmentDto>()
                .ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.department_name));
            CreateMap<DepartmentDto, Department>()
               .ForMember(dest => dest.department_name, opt => opt.MapFrom(src => src.DepartmentName));

            // Skill mapping
            CreateMap<Skill, SkillDto>()
                .ForMember(dest => dest.SkillName, opt => opt.MapFrom(src => src.skill_name));
            CreateMap<SkillDto, Skill>()
                .ForMember(dest => dest.skill_name, opt => opt.MapFrom(src => src.SkillName));

        }

    }
}
