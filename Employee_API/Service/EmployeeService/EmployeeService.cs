using Employee_API.Data;
using Shared_Library.Model;
using Microsoft.EntityFrameworkCore;
using Employee_API.Service.EmployeeService;
using Em.Service.EmployeeService;

namespace Employee_API.Service.EmployeeService
{
    public class EmployeeService : IEmployeeService
    {
        private readonly AppDbContext _dbContext;
        public EmployeeService(AppDbContext dbContext) 
        {
            _dbContext = dbContext;
        }
        public async Task<List<Employee>> AddEmployee(Employee employee)
        {
            _dbContext.Employees.Add(employee);
            await _dbContext.SaveChangesAsync();
            return await _dbContext.Employees.ToListAsync();
        }

        public  async Task<List<Employee>?> DeleteEmployee(int id)
        {
            var emp = await _dbContext.Employees.FirstOrDefaultAsync(e => e.Id == id);
            if (emp is null)           
                return null;            

            _dbContext.Employees.Remove(emp);
            await _dbContext.SaveChangesAsync();
            return await _dbContext.Employees.ToListAsync();
        }

        public async Task<List<Employee>> GetAllEmployees()
        {
            var emp = await _dbContext.Employees.ToListAsync();
            return emp;
        }

        public async Task<Employee?> GetById(int id)
        {
            var emp = await _dbContext.Employees.FirstOrDefaultAsync(e => e.Id == id);
            if (emp is null)
                return null;
            return emp;
        }

        public async Task<List<Employee>?> UpdateEmployee(int id, Employee request)
        {
            var emp = await _dbContext.Employees.FirstOrDefaultAsync(e => e.Id == id);
            if (emp is null)
                return null;

            emp.Name = request.Name;
            emp.Designation = request.Designation;
            emp.City = request.City;

            await _dbContext.SaveChangesAsync();
            return await _dbContext.Employees.ToListAsync();
        }
    }
}
