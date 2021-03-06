﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebStoreApp.Domain.ViewModels;
using WebStoreApp.Interfaces.Services;

namespace WebStoreApp.Controllers
{
    [Authorize]
    public class UserProfileController : Controller
    {
        public IActionResult Index() => View();

        public async Task<IActionResult> Orders([FromServices] IOrderService OrderService)
        {
            var orders = await OrderService.GetUserOrders(User.Identity.Name);

            return View(orders.Select(order => new UserOrderViewModel
            {
                Id = order.Id,
                Address = order.Address,
                Name = order.Name,
                Phone = order.Phone,
                TotalSum = order.Items.Sum(i => i.Price * i.Quantity)
            }));
        }
    }
}
