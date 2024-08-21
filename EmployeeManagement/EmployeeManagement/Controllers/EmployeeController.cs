using EmployeeManageProject.Data;
using EmployeeManageProject.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace EmployeeManageProject.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmployeeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult GetEmployees()
        {
            return View();
        }



        [HttpGet]
        public JsonResult GetEmployees1()
        {

            var employees = _context.EmployeeDetails.ToList();
            return Json(employees);
        }

        [HttpPost]
        public JsonResult addEmployee(EmployeeDetail employee)
        {
            EmployeeDetail emp = new EmployeeDetail()
            {
                Name = employee.Name,
                CompanyName = employee.CompanyName,
                Designation = employee.Designation

            };

            _context.EmployeeDetails.Add(emp);
            _context.SaveChanges();
            return Json(new { success = true });
        }

        [HttpDelete]
        public IActionResult DeleteEmployee(int id)
        {
            var employee = _context.EmployeeDetails
                                   .FirstOrDefault(u => u.Id == id);

            if (employee == null)
            {
                return Json(new { success = false });
            }

            _context.EmployeeDetails.Remove(employee);
            _context.SaveChanges();

            return Json(new { success = true });
        }

        [HttpGet]
        public IActionResult GetEmployeeById(int id)
        {
            var employee = _context.EmployeeDetails.FirstOrDefault(u => u.Id == id);
            if (employee == null)
                return NotFound();
            return Json(employee);
        }
        [HttpPost]
        public IActionResult UpdateEmployee(EmployeeDetail employee)
        {

            var emp = new EmployeeDetail()
            {
                Id = employee.Id,
                Name = employee.Name,
                CompanyName = employee.CompanyName,
                Designation = employee.Designation
            };
            
            _context.EmployeeDetails.Update(emp);
            _context.SaveChanges();
            return Json(emp);
        }
    }
}


