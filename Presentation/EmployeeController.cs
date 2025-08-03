using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController(IServiceManager serviceManager) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllEmployees()
        {
            var employees = await serviceManager.EmployeeService.GetAllEmployeesAsync();
            if (employees is null) return NotFound("No employees found.");
            return Ok(employees);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeById(int id)
        {
            var employee = await serviceManager.EmployeeService.GetEmployeeByIdAsync(id);
            if (employee is null) return NotFound($"Employee with ID {id} not found.");
            return Ok(employee);
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployee([FromBody] EmployeeResultByIdDto employeeDto)
        {
            if (employeeDto is null) return BadRequest("Employee data is null");
            await serviceManager.EmployeeService.AddEmployeeAsync(employeeDto);
            return Ok(employeeDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee(int id, [FromBody] EmployeeResultByIdDto employeeDto)
        {
            if (id != employeeDto.EmployeeId) return BadRequest("Employee ID mismatch");
            await serviceManager.EmployeeService.UpdateEmployee(employeeDto);
            return Ok(employeeDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            await serviceManager.EmployeeService.DeleteEmployeeAsync(id);
            return NoContent();
        }

    }
}
