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
        
        public IActionResult Index() => View();

        #region Каждый в свой контроллер отправить

        public IActionResult Cart() => View();

        public IActionResult CheckOut() => View();

        public IActionResult ContactUs() => View();

        public IActionResult Login() => View();

        public IActionResult ProductDetails() => View();

        public IActionResult Shop() => View();
        #endregion
    }
}
