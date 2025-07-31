using Domain.Models;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Transitty.Shared;

namespace Services.Abstractions
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeResultDto>> GetAllEmployeesAsync();

        Task<EmployeeResultByIdDto?> GetEmployeeByIdAsync(int id);

        Task AddEmployeeAsync(EmployeeResultByIdDto employee);

        Task UpdateEmployee(EmployeeResultByIdDto employee);

        Task DeleteEmployeeAsync(int employeeId);


        Task<bool> EmployeeExistsAsync(Expression<Func<Employee, bool>> predicate);
    }
}
