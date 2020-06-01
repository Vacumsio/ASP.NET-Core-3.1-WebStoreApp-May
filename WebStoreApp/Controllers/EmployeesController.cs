using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebStoreApp.Models;

namespace WebStoreApp.Controllers
{
    public class EmployeesController : Controller
    {       
        public IActionResult Index() => View(_Employees);

        public IActionResult EmployeeDetails(int id)
        {
            var employee = _Employees.FirstOrDefault(e => e.Id == id);
            if (employee is null)
            {
                return NotFound();
            }
            return View(employee);
        }
        
    }
}
