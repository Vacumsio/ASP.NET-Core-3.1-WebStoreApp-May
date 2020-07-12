using Microsoft.AspNetCore.Mvc;
using System;

namespace WebStoreApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index() => View();

        public IActionResult Throw(string id) => throw new ApplicationException(id ?? "Error!");
    }
}
