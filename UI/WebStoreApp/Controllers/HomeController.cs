﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebStoreApp.ViewModels;

namespace WebStoreApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index() => View();
    }
}