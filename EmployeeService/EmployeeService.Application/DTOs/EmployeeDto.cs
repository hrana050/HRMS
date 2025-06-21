using EmployeeService.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeService.Application.DTOs
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        public string emp_first_name { get; set; } = string.Empty;
        public string emp_last_name { get; set; } = string.Empty;
        public string emp_email { get; set; } = string.Empty;
        public DateTime emp_joining_date { get; set; }
        public decimal emp_salary { get; set; }
       // public int DepartmentId { get; set; }
        public string DepartmentName { get; set; } = string.Empty;
        public EmployeeType EmployeeType { get; set; }
      //  public List<int> SkillIds { get; set; } = new();
        public List<string> SkillNames { get; set; } = new();
    }
}
