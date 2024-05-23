using Shared_Library.Model;
using Employee_API.Service.EmployeeService;
using Microsoft.AspNetCore.Mvc;
using Em.Service.EmployeeService;
using Microsoft.AspNetCore.Authorization;

namespace Employee_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
           _employeeService = employeeService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Employee>>> GetAllEmployees()
        {
            return await _employeeService.GetAllEmployees();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetById(int id)
        {
            var result = await _employeeService.GetById(id);
            if (result is null)
                return NotFound("Employee not found.");

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<List<Employee>>> AddEmployee(Employee employee)
        {
            var result = await _employeeService.AddEmployee(employee);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<Employee>>> UpdateEmployee(int id, Employee request)
        {
            var result = await _employeeService.UpdateEmployee(id, request);
            if (result is null)
                return NotFound("Employee not found.");

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Employee>>> DeleteEmployee(int id)
        {
            var result = await _employeeService.DeleteEmployee(id);
            if (result is null)
                return NotFound("Employee not found.");

            return Ok(result);
        }
    }
}
