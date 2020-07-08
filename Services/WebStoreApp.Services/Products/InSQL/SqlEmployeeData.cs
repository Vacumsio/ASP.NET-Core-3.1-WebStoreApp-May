using System;
using System.Collections.Generic;
using WebStoreApp.DAL.Context;
using WebStoreApp.Domain.Entities.Employees;
using System.Linq;
using WebStoreApp.Interfaces.Services;
using Microsoft.Extensions.Logging;

namespace WebStoreApp.Services.Products.InSQL
{
    public class SqlEmployeeData : IEmployeesData
    {
        private readonly WebStoreDB _db;
        private readonly ILogger<SqlEmployeeData> _Logger;

        public SqlEmployeeData(WebStoreDB db, ILogger<SqlEmployeeData> Logger)
        {
            _db = db;
            _Logger = Logger;
        }
        public int Add(Employee Employee)
        {
            if (Employee is null) throw new ArgumentNullException(nameof(Employee));
            if (Employee.Id != 0) throw new InvalidOperationException("Для присвоение порядкового номера предусмотрен первичный ключ");

            _db.Employees.Add(Employee);

            return Employee.Id;
        }

        public bool Delete(int id)
        {
            var employee = _db.Employees.FirstOrDefault(e => e.Id == id);
            if (employee is null) return false;

            _db.Remove(employee);
            return true;
        }

        public void Edit(Employee Employee)
        {
            if (Employee is null)
            {
                throw new ArgumentNullException(nameof(Employee));

            }
            _db.Update(Employee);
        }

        public IEnumerable<Employee> Get() => _db.Employees;

        public Employee GetById(int id) => _db.Employees.FirstOrDefault(e => e.Id == id);

        public void SaveChanges() => _db.SaveChanges();
    }
}
