using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger<EmployeesClient> _Logger;
        public EmployeesClient(IConfiguration Configuration, ILogger<EmployeesClient> Logger)
            : base(Configuration, WebApi.Employees) =>
            _Logger = Logger;

        
        public int Add(Employee Employee) 
        {
            try
            {
                _Logger.LogInformation("Запрос к {0} на редактирование сотрудника id: {1}", _ServiceAddress, Employee.Id);
                return Post(_ServiceAddress, Employee).Content.ReadAsAsync<int>().Result;
            }
            catch (Exception error)
            {

                _Logger.LogError("Ошибка при выполнении запроса к {0} на редактирование сотрудника {1}: {2}",
                    _ServiceAddress, Employee.Id, error);

                throw new InvalidOperationException(
                    $"Ошибка при выполнении запроса к {_ServiceAddress} на редактирование сотрудника {Employee.Id}",
                    error);
            }
        }//public int Add(Employee Employee) => Post(_ServiceAddress, Employee).Content.ReadAsAsync<int>().Result;

        public IEnumerable<Employee> Get() => Get<IEnumerable<Employee>>(_ServiceAddress);

        public Employee GetById(int id) => Get<Employee>($"{_ServiceAddress}/{id}");


        public void Edit(Employee Employee) => Put(_ServiceAddress, Employee);

        public bool Delete(int id) => Delete($"{_ServiceAddress}/{id}").IsSuccessStatusCode;

        public void SaveChanges() { }
    }
}
