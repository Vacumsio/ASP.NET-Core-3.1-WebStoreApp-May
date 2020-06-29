using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using WebStoreApp.Clients.Base;
using WebStoreApp.Domain;
using WebStoreApp.Domain.Entities.Employees;
using WebStoreApp.Interfaces.Services;

namespace WebStoreApp.Clients.Employees
{
    public class EmployeesClient : BaseClient, IEmployeesData
    {
        public EmployeesClient(IConfiguration Configuration) : base(Configuration, WebApi.Employees) { }

        public int Add(Employee Employee) => throw new NotImplementedException();

        public bool Delete(int id) => throw new NotImplementedException();

        public void Edit(Employee Employee) => throw new NotImplementedException();

        public IEnumerable<Employee> Get() => throw new NotImplementedException();

        public Employee GetById(int id) => throw new NotImplementedException();

        public void SaveChanges() => throw new NotImplementedException();
    }
}
