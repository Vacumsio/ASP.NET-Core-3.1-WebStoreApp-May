﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebStoreApp.Controllers
{
    public class _404Controller : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
