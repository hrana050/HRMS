using SharedKernel.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeService.Application.DTOs
{
    public class CreateEmployeeDto
    {
        public int Id { get; set; }
        public string emp_first_name { get; set; }
        public string emp_last_name { get; set; }
        public string emp_email { get; set; }
        public DateTime emp_joining_date { get; set; }
        public decimal emp_salary { get; set; }
        public int DepartmentId { get; set; }
        public List<int> SkillIds { get; set; } = new();
        public EmployeeType EmployeeType { get; set; }
    }
}
