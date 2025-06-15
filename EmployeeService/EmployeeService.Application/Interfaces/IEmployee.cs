using EmployeeService.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeService.Application.Interfaces
{
    public interface IEmployee
    {
        Task<int> CreateEmployeeAsync(EmployeeDto employeeDto);
        Task<bool> UpdateEmployeeAsync(EmployeeDto employeeDto);
        Task<bool> DeleteEmployeeAsync(int id);
        Task<IEnumerable<EmployeeDto>> GetAllEmployeesAsync();
        Task<EmployeeDto?> GetEmployeeByIdAsync(int id);
    }
}
