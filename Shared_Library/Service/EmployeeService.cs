using Shared_Library.Model;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Shared_Library.Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly HttpClient _httpClient;

        public EmployeeService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Employee>> GetAllEmployees()
        {
            return await _httpClient.GetFromJsonAsync<List<Employee>>("api/Employee");
        }

        public async Task<Employee> GetEmployeeById(int id)
        {
            return await _httpClient.GetFromJsonAsync<Employee>($"api/Employee/{id}");
        }

        public async Task<List<Employee>> AddEmployee(Employee employee)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Employee", employee);
            return await response.Content.ReadFromJsonAsync<List<Employee>>();
        }

        public async Task<List<Employee>> UpdateEmployee(int id, Employee employee)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/Employee/{id}", employee);
            return await response.Content.ReadFromJsonAsync<List<Employee>>();
        }

        public async Task<List<Employee>> DeleteEmployee(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/Employee/{id}");
            return await response.Content.ReadFromJsonAsync<List<Employee>>();
        }
    }
}
