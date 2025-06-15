using SharedKernel.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeService.Domain.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public string first_name { get; set; } = string.Empty;
        public string last_name { get; set; } = string.Empty;
        public string email { get; set; } = string.Empty;
        public DateTime joining_date { get; set; }
        public decimal salary { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; } = null!;
        public ICollection<Skill> Skills { get; set; } = new List<Skill>();
        public EmployeeType EmployeeType { get; set; }

    }
}
