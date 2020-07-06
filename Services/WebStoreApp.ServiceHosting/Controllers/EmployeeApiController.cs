using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebStoreApp.Domain;
using WebStoreApp.Domain.Entities.Employees;
using WebStoreApp.Interfaces.Services;

namespace WebStoreApp.ServiceHosting.Controllers
{
    /// <summary>Управление сотрудниками</summary>
    [Route(WebApi.Employees)]
    [ApiController]
    public class EmployeeApiController : ControllerBase, IEmployeesData
    {
        private readonly IEmployeesData _EmployeesData;
        private readonly ILogger<EmployeeApiController> _Logger;


        /// <summary>
        /// Конструктор Класса
        /// </summary>
        /// <param name="EmployeesData"></param>
        /// <param name="Logger"></param>
        public EmployeeApiController(IEmployeesData EmployeesData, ILogger<EmployeeApiController> Logger)
        {
            _EmployeesData = EmployeesData;
            _Logger = Logger;
        }

        /// <summary>Получить всех сотрудников</summary>
        /// <returns>Перечисление сотрудников магазина</returns>
        [HttpGet]
        public IEnumerable<Employee> Get() => _EmployeesData.Get();

        /// <summary>Получить сотрудника по его идентификатору</summary>
        /// <param name="id">Числовой идентификатор сотрудника</param>
        /// <returns>Сотрудник с указанным идентификатором</returns>
        [HttpGet("{id}")]
        public Employee GetById(int id) => _EmployeesData.GetById(id);

        /// <summary>Добавление нового сотрудника</summary>
        /// <param name="Employee">Добавляемый сотрудник</param>
        /// <returns>Идентификатор добавленного сотрудника</returns>
        [HttpPost]
        public int Add(Employee Employee)
        {
            _Logger.LogInformation("Добавление нового сотрудника {0}{1}{2}{3}",Employee.Id,Employee.Firstname,Employee.Surname,Employee.Patronymic);
            var v = _EmployeesData.Add(Employee);
            SaveChanges();
            return v;
        }

        /// <summary>Редактирование данных сотрудника</summary>
        /// <param name="Employee">Редактируемый сотрудник</param>
        [HttpPut]
        public void Edit(Employee Employee)
        {
            _Logger.LogInformation("Редактирование сотрудника {0}{1}{2}{3}", Employee.Id, Employee.Firstname, Employee.Surname, Employee.Patronymic);
            _EmployeesData.Edit(Employee);
            SaveChanges();
        }

        /// <summary>Удаление сотрудника по его идентификатору</summary>
        /// <param name="id">Идентификатор удаляемого сотрудника</param>
        /// <returns>Истина, если сотрудник присутствовал и был удалён</returns>
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            _Logger.LogInformation("Удаление сотрудника id : {0}", id);
            var v = _EmployeesData.Delete(id);
            SaveChanges();
            return v;
        }

        /// <summary>
        /// Метод сохранения данных
        /// </summary>
        [NonAction]
        public void SaveChanges() => _EmployeesData.SaveChanges();
    }
}
