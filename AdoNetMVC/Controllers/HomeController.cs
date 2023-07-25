 using System;
using System.Data;
using System.Data.SqlClient;
using AdoNetMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace AdoNetMVC.Controllers
{
    public class HomeController : Controller
	{
        public async Task<IActionResult> Index()
        {
            string connStr = "Server=MacDesktop;Database=AmazonSuperMarket;Trusted_Connection=true";
            List<Employee> employees = new List<Employee>();
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                await conn.OpenAsync();
                using (SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM Employee",conn))
                {
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    foreach(DataRow item in dt.Rows)
                    {
                        employees.Add(new Employee
                        {
                            Id = (int)item["Id"],
                            Name = (string)item["Name"],
                            Surname = (string)item["Surname"],
                            FatherName = (string)item["FatherName"],
                            Salary = (int)item["Salary"],
                            PositionId = (int)item["PositionId"],
                        }); 
                    }
                }
            }
            return View(employees); 
        }

    }
}
 
