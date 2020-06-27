﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebStoreApp.Interfaces.TestApi;

namespace WebStoreApp.Controllers
{
    public class WebApiTestController : Controller
    {
        private readonly IValueService _ValueService;

        public WebApiTestController(IValueService ValueService) => _ValueService = ValueService;
        public IActionResult Index()
        {
            var values = _ValueService.Get();
            return View(values);
        }
    }
}
