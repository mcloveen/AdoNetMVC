using AdoNetMVC.Models;

namespace AdoNetMVC.Services.Interfaces
{

    public interface IEmployeeService
    {
        public Task<int> AddAsync(Employee employee);
        public Task<int> AddAsync(List<Employee> employees);
        public Task<List<Employee>> GetAllAsync();
        public Task<Employee> GetByIdAsync(int id);
        public Task<int> Delete(int id);
        public Task<Employee> Update(int id, Employee employee);
        Task AddAsyn(Employee employee);
        Task<object> AddAsnc(Employee employee);
        Task AddAsy(Employee employee);
    }

}

