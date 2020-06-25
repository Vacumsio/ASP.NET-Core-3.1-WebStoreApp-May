using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStoreApp.Domain.Entities.Employees;
using WebStoreApp.ViewModels;

namespace WebStoreApp.Infrastructure.Mapping
{
    public static class EmployeeMapper
    {
        public static EmployeeViewModel ToView(this Employee e) => new EmployeeViewModel
        {
            Id = e.Id,
            Firstname = e.Firstname,
            Surname = e.Surname,
            Patronymic = e.Patronymic,
            Age = e.Age,
        };

        public static Employee FromView(this EmployeeViewModel e) => new Employee
        {
            Id = e.Id,
            Firstname = e.Firstname,
            Surname = e.Surname,
            Patronymic = e.Patronymic,
            Age = e.Age,
        };
    }
}
