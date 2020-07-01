using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
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
        /// <summary>
        /// Конструктор Класса
        /// </summary>
        /// <param name="EmployeesData"></param>
        public EmployeeApiController(IEmployeesData EmployeesData) => _EmployeesData = EmployeesData;

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
            var v = _EmployeesData.Add(Employee);
            SaveChanges();
            return v;
        }

        /// <summary>Редактирование данных сотрудника</summary>
        /// <param name="Employee">Редактируемый сотрудник</param>
        [HttpPut]
        public void Edit(Employee Employee)
        {
            _EmployeesData.Edit(Employee);
            SaveChanges();
        }

        /// <summary>Удаление сотрудника по его идентификатору</summary>
        /// <param name="id">Идентификатор удаляемого сотрудника</param>
        /// <returns>Истина, если сотрудник присутствовал и был удалён</returns>
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
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
