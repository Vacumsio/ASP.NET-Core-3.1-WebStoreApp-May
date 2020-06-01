using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStoreApp.Data;
using WebStoreApp.Infrastructure.Interfaces;
using WebStoreApp.Models;

namespace WebStoreApp.Infrastructure.Services
{
    public class InMemoryEmpolyeeData : IEmployeeData
    {
        private readonly List<Employee> _Employees = TestData.Employees;

        public IEnumerable<Employee> Get() => _Employees;

        public Employee GetById(int id) => _Employees.FirstOrDefault(e => e.Id == id);

        public int Add(Employee Employee)
        {
            if (Employee is null)
            {
                throw new ArgumentNullException(nameof(Employee));
            }
            if (_Employees.Contains(Employee))
            {
                return Employee.Id;
            }

            Employee.Id = _Employees.Count == 0 ? 1 : _Employees.Max(e => e.Id) + 1;
            _Employees.Add(Employee);
            return Employee.Id;
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Edit(Employee Employee)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
