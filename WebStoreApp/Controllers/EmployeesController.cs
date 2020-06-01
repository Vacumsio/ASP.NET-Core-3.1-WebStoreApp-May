using Microsoft.AspNetCore.Mvc;
using WebStoreApp.Infrastructure.Interfaces;

namespace WebStoreApp.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly IEmployeeData _EmployeeData;
        public EmployeesController(IEmployeeData EmployeeData)
        {
            _EmployeeData = EmployeeData;
        }
        public IActionResult Index() => View(_EmployeeData);

        public IActionResult EmployeeDetails(int id)
        {
            var employee = _EmployeeData.GetById(id);
            if (employee is null)
            {
                return NotFound();
            }
            return View(employee);
        }
        
    }
}
