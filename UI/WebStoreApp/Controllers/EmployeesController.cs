﻿using Microsoft.AspNetCore.Mvc;
using System;
using WebStoreApp.Domain.Entities.Employees;
using Microsoft.AspNetCore.Authorization;
using WebStoreApp.Domain.Entities.Identity;
using AutoMapper;
using WebStoreApp.Domain.ViewModels;
using WebStoreApp.Interfaces.Services;

namespace WebStoreApp.Controllers
{
    [Authorize]
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

        [Authorize(Roles = Role.Administrator)]
        public IActionResult Edit(int? Id, [FromServices] IMapper Mapper)
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

            return View(Mapper.Map<EmployeeViewModel>(employee));
        }
        
        [HttpPost]
        [Authorize(Roles = Role.Administrator)]
        public IActionResult Edit(EmployeeViewModel Model, [FromServices] IMapper Mapper)
        {
            if (Model is null)
            {
                throw new ArgumentNullException(nameof(Model));
            }
            if (!ModelState.IsValid)
            {
                return View(Model);
            }
            var employee = Mapper.Map<Employee>(Model);

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

        [Authorize(Roles = Role.Administrator)]
        public IActionResult Delete(int Id, [FromServices] IMapper Mapper)
        {
            if (Id <= 0)
            {
                return BadRequest();
            }
            var employee = _EmployeesData.GetById(Id);
            if (employee is null)
            {
                return NotFound();
            }
            return View(Mapper.Map<EmployeeViewModel>(employee));
        }
        
        [HttpPost]
        [Authorize(Roles = Role.Administrator)]
        public IActionResult DeleteConfirmed(int Id)
        {
            _EmployeesData.Delete(Id);
            _EmployeesData.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
