using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVCCoreAngular.Models;
using MVCCoreAngular.Data;

namespace MVCCoreAngular.Controllers
{
    public class HomeController : Controller
    {
        private readonly EmployeeContext _context;
        public HomeController(EmployeeContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        //GET: /Home/Details
        public IActionResult Details()
        {
            ViewData["Message"] = "Task 3 Demo Application";

            return View();
        }
        //GET: /Home/GetDetails
        [HttpGet]
        public JsonResult GetDetails()
        {
            _context.Database.EnsureCreated();
            IEnumerable<Employee> EmployeeList = (from e in _context.Employees select e).ToList();
            return Json(EmployeeList);
        }


        public string UpdateEmployee(Employee Emp)
        {
            if (Emp != null)
            {
                int no = Convert.ToInt32(Emp.EmployeeId);
                Employee employeeList = _context.Employees.Where(x => x.EmployeeId == no).FirstOrDefault();
                employeeList.EmployeeCode = strfixer(Emp.EmployeeCode);
                employeeList.FirstName = strfixer(Emp.FirstName);
                employeeList.LastName = strfixer(Emp.LastName);
                _context.SaveChanges();
                return "Employee Updated";
            }
            else
            {
                return "Invalid Employee";
            }
        }

        [HttpPost]
        public string DeleteEmployee(Employee Emp)
        {
            if (Emp != null)
            {
                int no = Convert.ToInt32(Emp.EmployeeId);
                var employeeList = _context.Employees.Where(x => x.EmployeeId == no).FirstOrDefault();
                _context.Employees.Remove(employeeList);
                _context.SaveChanges();
                return "Employee Deleted";
            }
            else
            {
                return "Invalid Employee";
            }
        }

        public JsonResult getEmployeeByNo(string EmpNo)
        {
            int no = Convert.ToInt32(EmpNo);
            var employeeList = _context.Employees.Find(no);
            return Json(employeeList);
        }

        private string strfixer(string tofix)
        {
            return tofix.Replace("\"", "");
        }
        [HttpPost]
        public string AddEmployee(Employee Emp)
        {
            if (Emp != null)
            {
                Employee e = new Employee();
                e.EmployeeCode = strfixer(Emp.EmployeeCode);
                e.FirstName = strfixer(Emp.FirstName);
                e.LastName = strfixer(Emp.LastName);
                _context.Employees.Add(e);
                _context.SaveChanges();
                return "Employee Updated";

            }
            else
            {
                return "Invalid Employee";
            }
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Task 3 Demo Application";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Ryan Richard";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
