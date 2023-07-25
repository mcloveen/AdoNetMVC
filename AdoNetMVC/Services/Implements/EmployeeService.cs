using System.Data;
using AdoNetMVC.Helpers;
using AdoNetMVC.Models;
using AdoNetMVC.Services.Interfaces;


namespace AdoNetMVC.Services.Implements
{
    public class EmployeeService : IEmployeeService
    {
        public async Task<int> AddAsync(Employee employee)
        {
            return await SqlHelper.ExecuteAsync($"INSERT INTO Employees (Name, Surname, FatherName, PositionId) VALUES ('{employee.Name}', '{employee.Surname}', '{employee.FatherName}', {employee.PositionId})");
        }

        public async Task<int> AddAsync(List<Employee> employees)
        {
            string query = "INSERT INTO Employees (Name, Surname, FatherName, PositionId) VALUES ";
            foreach (Employee employee in employees)
            {
                query += $"('{employee.Name}', '{employee.Surname}', '{employee.FatherName}', {employee.PositionId}),";
            }
            return await SqlHelper.ExecuteAsync(query.Substring(0, query.Length - 1));
        }

        public async Task<int> Delete(int id)
        {
            await GetByIdAsync(id);
            return await SqlHelper.ExecuteAsync("DELETE FROM Employees WHERE Id = " + id);
        }

        public async Task<List<Employee>> GetAllAsync()
        {
            List<Employee> list = new List<Employee>();
            DataTable dt = await SqlHelper.SelectAsync("SELECT * FROM Employees");
            foreach (DataRow item in dt.Rows)
            {
                list.Add(new Employee
                {
                    Id = (int)item["Id"],
                    Name = (string)item["Name"],
                    Surname = (string)(item["Surname"]),
                    FatherName = (string)item["FatherName"],
                    Salary = (int)item["Salary"],
                    PositionId = (int)item["PositionId"]
                });
            }
            return list;
        }

        public async Task<Employee> GetByIdAsync(int id)
        {
            DataTable dt = await SqlHelper.SelectAsync("SELECT * FROM Employees WHERE Id = " + id);
            if (dt.Rows.Count != 1) throw new Exception("Error");
            return new Employee
            {
                Id = (int)dt.Rows[0]["Id"],
                Name = (string)dt.Rows[0]["Name"],
                Surname = (string)dt.Rows[0]["Surname"],
                FatherName = (string)dt.Rows[0]["FatherName"],
                Salary = (int)dt.Rows[0]["Salary"],
                PositionId = (int)dt.Rows[0]["PositionId"]
            };
        }

        public async Task<int> Update(int id, Employee employee)
        {
            await GetByIdAsync(id);
            return await SqlHelper.ExecuteAsync($"UPDATE Employees SET Name = '{employee.Name}', Surname = '{employee.Surname}', FatherName = '{employee.FatherName}', PositionId = {employee.PositionId} WHERE Id = {id}");
        }

        Task<object> IEmployeeService.AddAsnc(Employee employee)
        {
            throw new NotImplementedException();
        }

        Task IEmployeeService.AddAsy(Employee employee)
        {
            throw new NotImplementedException();
        }

        Task IEmployeeService.AddAsyn(Employee employee)
        {
            throw new NotImplementedException();
        }

        Task<int> IEmployeeService.AddAsync(Employee music)
        {
            throw new NotImplementedException();
        }

        Task<int> IEmployeeService.AddAsync(List<Employee> musics)
        {
            throw new NotImplementedException();
        }

        Task<int> IEmployeeService.Delete(int id)
        {
            throw new NotImplementedException();
        }

        Task<List<Employee>> IEmployeeService.GetAllAsync()
        {
            throw new NotImplementedException();
        }

        Task<Employee> IEmployeeService.GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<Employee> IEmployeeService.Update(int id, Employee employee)
        {
            throw new NotImplementedException();
        }
    }
}

