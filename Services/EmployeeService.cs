using AutoMapper;
using Domain.Contracts;
using Domain.Exceptions;
using Domain.Models;
using Services.Abstractions;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class EmployeeService(IMapper mapper, IUnitOfWork unitOfWork) : IEmployeeService
    {
        public async Task<IEnumerable<EmployeeResultDto>> GetAllEmployeesAsync()
        {
            var employess = await unitOfWork.GetRepository<Employee>().GetAllAsync();
            var result = mapper.Map<IEnumerable<EmployeeResultDto>>(employess);
            return result;
        }

        public async Task<EmployeeResultByIdDto?> GetEmployeeByIdAsync(int id)
        {
            var employee = await unitOfWork.GetRepository<Employee>().GetByIdAsync(id);
            if (employee is null) throw new EmployeeNotFoundException("Employee Not Found Or Not Available");
            var result = mapper.Map<EmployeeResultByIdDto>(employee);
            return result;
        }

        public async Task AddEmployeeAsync(EmployeeResultByIdDto employee)
        {
            var newEmployee = mapper.Map<Employee>(employee);
            await unitOfWork.GetRepository<Employee>().AddAsync(newEmployee);
            var result = await unitOfWork.SaveChangesAsync();
            if (result == 0) throw new AddingNewEmployeeBadRequestException("Employee Is Not Added");
        }

        public async Task UpdateEmployee(EmployeeResultByIdDto employee)
        {
            var result = mapper.Map<Employee>(employee);
            unitOfWork.GetRepository<Employee>().Update(result);
            var resultt= await unitOfWork.SaveChangesAsync();
            if (resultt == 0) throw new EmployeeNotFoundException("Employee Not Updated");
        }

        public async Task DeleteEmployeeAsync(int employeeId)
        {
            var employee = await unitOfWork.GetRepository<Employee>().GetByIdAsync(employeeId);
            if (employee is null) throw new EmployeeNotFoundException("Employee Not Found Or Not Available");
            unitOfWork.GetRepository<Employee>().Delete(employee);
            var result = await unitOfWork.SaveChangesAsync();
            if (result == 0) throw new EmployeeNotFoundException("Employee Is Not Deleted");
        }

        public async Task<bool> EmployeeExistsAsync(Expression<Func<Employee, bool>> predicate)
        {
            return await unitOfWork.GetRepository<Employee>().ExistsAsync(predicate);
        }
    }
}
