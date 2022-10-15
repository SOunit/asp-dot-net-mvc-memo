using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace asp_dot_net_mvc_demo.Controllers
{
    public class Employee
    {
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public string Job { get; set; }
        public double Salary { get; set; }
    }

    public class LinqVM
    {
        public IEnumerable<Employee> EmployeeList { get; set; }
    }

    public class LinqController : Controller
    {
        public IActionResult Index()
        {
            var vm = new LinqVM();

            List<Employee> employeeList = new List<Employee>()
            {
                new Employee {EmpId = 1, EmpName = "Test1", Job = "Job1", Salary = 1500},
                new Employee {EmpId = 2, EmpName = "Test2", Job = "Job2", Salary = 2500},
                new Employee {EmpId = 3, EmpName = "Test3", Job = "Job3", Salary = 3500},
                new Employee {EmpId = 4, EmpName = "Test4", Job = "Job4", Salary = 4500},
                new Employee {EmpId = 5, EmpName = "Test5", Job = "Job4", Salary = 4500},
                new Employee {EmpId = 6, EmpName = "Test6", Job = "Job4", Salary = 4500},
                new Employee {EmpId = 7, EmpName = "Test7", Job = "Job4", Salary = 4500},
            };

            vm.EmployeeList = employeeList;

            return View(vm);
        }
    }
}
