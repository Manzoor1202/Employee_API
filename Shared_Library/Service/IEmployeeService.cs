using Shared_Library.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shared_Library.Service
{
    public interface IEmployeeService
    {
        Task<List<Employee>> GetAllEmployees();
        Task<Employee> GetEmployeeById(int id);
        Task<List<Employee>> AddEmployee(Employee employee);
        Task<List<Employee>> UpdateEmployee(int id, Employee employee);
        Task<List<Employee>> DeleteEmployee(int id);
    }
}
