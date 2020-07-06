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
            if (Employee is null)
            {
                _Logger.LogDebug("Employee пустое {0}", Employee.Id);
                throw new ArgumentNullException(nameof(Employee));
            }

            if (Employee.Id != 0)
            {
                _Logger.LogDebug("Employee.Id не равно нулю {0}", Employee.Id);
                throw new InvalidOperationException("Для присвоение порядкового номера предусмотрен первичный ключ");
            }
            _Logger.LogInformation("Добавление сотрудника : {0} {1} {2} {3}", Employee.Id, Employee.Firstname, Employee.Surname, Employee.Patronymic);
            _db.Employees.Add(Employee);

            return Employee.Id;
        }

        public bool Delete(int id)
        {
            var employee = _db.Employees.FirstOrDefault(e => e.Id == id);
            if (employee is null)
            {
                _Logger.LogDebug("Employee.Id пустое {0}", id);
                return false;
            }

            _Logger.LogInformation("Удаление сотрудника : {0}", id);
            _db.Remove(employee);
            return true;
        }

        public void Edit(Employee Employee)
        {
            if (Employee is null)
            {
                _Logger.LogDebug("Employee пустое {0}", Employee.Id);
                throw new ArgumentNullException(nameof(Employee));
            }

            _Logger.LogInformation("Обновление инфомрации о сотруднике :{0}{1}{2}{3}", Employee.Id, Employee.Firstname, Employee.Surname, Employee.Patronymic);
            _db.Update(Employee);
        }

        public IEnumerable<Employee> Get() => _db.Employees;

        public Employee GetById(int id) => _db.Employees.FirstOrDefault(e => e.Id == id);

        public void SaveChanges() => _db.SaveChanges();
    }
}
