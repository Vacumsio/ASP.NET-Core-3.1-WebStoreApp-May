﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebStoreApp.Infrastructure.Interfaces;
using WebStoreApp.ViewModels;

namespace WebStoreApp.Controllers
{
    public class UserProfileController : Controller
    {
        public IActionResult Index() => View();

        public async Task<IActionResult> Orders([FromServices] IOrderService OrderService)
        {
            var orders = await OrderService.GetUserOrders(User.Identity.Name);

            return View(orders.Select(order => new UserOrderViewModel
            {
               Id =order.Id,
               Address = order.Address,
               Name = order.Name,
               Phone = order.Phone,
               TotalSum = order.Items.Sum(i => i.Price * i.Quantity)
            }));
        }
    }
}
