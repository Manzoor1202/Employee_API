using Shared_Library.Model;

namespace Em.Service.EmployeeService
{
    public interface IEmployeeService
    {
        public Task<List<Employee>> GetAllEmployees();
        public Task<Employee?> GetById(int id);
        public Task<List<Employee>> AddEmployee(Employee employee);
        public Task<List<Employee>?> UpdateEmployee(int id, Employee request);
        public Task<List<Employee>?> DeleteEmployee(int id);


    }
}
