using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebStoreApp.Domain.Entities.Employees;
using WebStoreApp.Interfaces.Services;

namespace WebStoreApp.ServiceHosting.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeApiController : ControllerBase, IEmployeesData
    {
        private readonly IEmployeesData _EmployeesData;

        public EmployeeApiController(IEmployeesData EmployeesData) => _EmployeesData = EmployeesData;

        [HttpGet]
        public IEnumerable<Employee> Get() => _EmployeesData.Get();

        [HttpGet("{id}")]
        public Employee GetById(int id) => _EmployeesData.GetById(id);

        [HttpPost]
        public int Add(Employee Employee)
        {
            var v = _EmployeesData.Add(Employee);
            SaveChanges();
            return v;
        }

        [HttpPut]
        public void Edit(Employee Employee)
        {
            _EmployeesData.Edit(Employee);
            SaveChanges();
        }

        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            var v = _EmployeesData.Delete(id);
            SaveChanges();
            return v;
        }

        public void SaveChanges() => _EmployeesData.SaveChanges();
    }
}
