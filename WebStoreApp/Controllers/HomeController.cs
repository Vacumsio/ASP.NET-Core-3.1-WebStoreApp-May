using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebStoreApp.Models;

namespace WebStoreApp.Controllers
{
    public class HomeController : Controller
    {
        private static readonly List<Employee> _Employees = new List<Employee>
        {
            new Employee
            {
                Id = 1,
                Firstname = "Arthas",
                Surname = "Pendragon",
                Patronymic = "Fallen",
                Age = 22
            },
            new Employee
            {
                Id = 2,
                Firstname = "Jaina",
                Surname = "Praudmur",
                Patronymic = "Great",
                Age = 20
            },
            new Employee
            {
                Id = 3,
                Firstname = "Thrall",
                Surname = "Overseer",
                Patronymic = "Chieftan",
                Age = 30
            },
            new Employee
            {
                Id = 4,
                Firstname = "Барыга",
                Surname = "Зона",
                Patronymic = "Сидорович",
                Age = 50
            },
        };
        public IActionResult Index() => View();
       
    }
}
