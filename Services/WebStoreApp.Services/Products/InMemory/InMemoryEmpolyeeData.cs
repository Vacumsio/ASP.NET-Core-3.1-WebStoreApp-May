using System;
using System.Collections.Generic;
using System.Linq;
using WebStoreApp.Domain.Entities.Employees;
using WebStoreApp.Interfaces.Services;
using WebStoreApp.Services.Data;

namespace WebStoreApp.Services.Products.InMemory
{
    [Obsolete("Руки прочь от Барбары, пользуйся БД", error:true)]
    public class InMemoryEmpolyeeData : IEmployeesData
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
            var db_item = GetById(id);
            if (db_item is null)
            {
                return false;
            }
            return _Employees.Remove(db_item);
        }

        public void Edit(Employee Employee)
        {
            if (Employee is null)
            {
                throw new ArgumentNullException(nameof(Employee));
            }
            if (_Employees.Contains(Employee))
            {
                return;
            }

            var db_item = GetById(Employee.Id);

            db_item.Firstname = Employee.Firstname;
            db_item.Surname = Employee.Surname;
            db_item.Patronymic = Employee.Patronymic;
            db_item.Age = Employee.Age;
        }

        public void SaveChanges() { }
    }
}
