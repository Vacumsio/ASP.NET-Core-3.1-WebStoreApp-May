using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net.Http;
using WebStoreApp.Clients.Base;
using WebStoreApp.Domain;
using WebStoreApp.Domain.Entities.Employees;
using WebStoreApp.Interfaces.Services;

namespace WebStoreApp.Clients.Employees
{
    public class EmployeesClient : BaseClient, IEmployeesData
    {
        public EmployeesClient(IConfiguration Configuration) : base(Configuration, WebApi.Employees) { }


        public IEnumerable<Employee> Get() => Get<IEnumerable<Employee>>(_ServiceAddress);

        public Employee GetById(int id) => Get<Employee>($"{_ServiceAddress}/{id}");

        public int Add(Employee Employee) => Post(_ServiceAddress, Employee).Content.ReadAsAsync<int>().Result;

        public void Edit(Employee Employee) => Put(_ServiceAddress, Employee);

        public bool Delete(int id) => Delete($"{_ServiceAddress}/{id}").IsSuccessStatusCode;

        public void SaveChanges() { }
    }
}
