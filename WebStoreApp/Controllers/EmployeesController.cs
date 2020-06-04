using Microsoft.AspNetCore.Mvc;
using System;
using WebStoreApp.Infrastructure.Interfaces;
using WebStoreApp.Models;

namespace WebStoreApp.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly IEmployeesData _EmployeesData;
        public EmployeesController(IEmployeesData EmployeeData)
        {
            _EmployeesData = EmployeeData;
        }
        public IActionResult Index() => View(_EmployeesData.Get());

        public IActionResult EmployeeDetails(int id)
        {
            var employee = _EmployeesData.GetById(id);
            if (employee is null)
            {
                return NotFound();
            }
            return View(employee);
        }

        public IActionResult Edit(int? Id)
        {
            if (Id is null)
            {
                return View(new EmployeeViewModel());
            }
            if (Id < 0)
            {
                return BadRequest();
            }

            var employee = _EmployeesData.GetById((int)Id);
            if (employee is null)
            {
                return NotFound();
            }

            return View(new EmployeeViewModel
            {
                Id = employee.Id,
                Firstname = employee.Firstname,
                Surname = employee.Surname,
                Patronymic = employee.Patronymic,
                Age = employee.Age
            });
        }
        [HttpPost]
        public IActionResult Edit(EmployeeViewModel Model)
        {
            if (Model is null)
            {
                throw new ArgumentNullException(nameof(Model));
            }
            if (!ModelState.IsValid)
            {
                return View(Model);
            }
            var employee = new Employee
            {
                Id = Model.Id,
                Firstname = Model.Firstname,
                Surname = Model.Surname,
                Patronymic = Model.Patronymic,
                Age = Model.Age
            };

            if (Model.Id == 0)
            {
                _EmployeesData.Add(employee);
            }
            else
            {
                _EmployeesData.Edit(employee);
            }
            _EmployeesData.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int Id)
        {
            if (Id<=0)
            {
                return BadRequest();
            }
            var employee = _EmployeesData.GetById(Id);
            if (employee is null)
            {
                return NotFound();
            }
            return View(new EmployeeViewModel
            {
                Id = employee.Id,
                Firstname = employee.Firstname,
                Surname = employee.Surname,
                Patronymic = employee.Patronymic,
                Age = employee.Age
            });
        }
        [HttpPost]
        public IActionResult DeleteConfirmed(int Id)
        {
            _EmployeesData.Delete(Id);
            _EmployeesData.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
