using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
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
        public int Add(Employee Employee) => _EmployeesData.Add(Employee);

        [HttpPut]
        public void Edit(Employee Employee) => _EmployeesData.Edit(Employee);

        [HttpDelete("{id}")]
        public bool Delete(int id) => _EmployeesData.Delete(id);

        public void SaveChanges() => _EmployeesData.SaveChanges();
    }
}
