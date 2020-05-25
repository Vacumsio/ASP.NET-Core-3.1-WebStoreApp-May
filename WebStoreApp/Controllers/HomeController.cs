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
        private static readonly List<Employee> _employees = new List<Employee>
        {
            new Employee
            {
                Id = 1,
                FirstName = "Arthas",
                Surname = "Pendragon",
                Patronymic = "Fallen",
                Age = 22
            },
            new Employee
            {
                Id = 1,
                FirstName = "Jaina",
                Surname = "Praudmur",
                Patronymic = "Great",
                Age = 20
            },
            new Employee
            {
                Id = 1,
                FirstName = "Thrall",
                Surname = "Overseer",
                Patronymic = "Chieftan",
                Age = 30
            },
            new Employee
            {
                Id = 1,
                FirstName = "Барыга",
                Surname = "Зона",
                Patronymic = "Сидорович",
                Age = 50
            },
        };
        public IActionResult Index()
        {
            return View();
        }
    }
}
