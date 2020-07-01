﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStoreApp.DAL.Context;
using WebStoreApp.Domain.DTO.Order;
using WebStoreApp.Domain.Entities.Identity;
using WebStoreApp.Domain.Entities.Orders;
using WebStoreApp.Domain.ViewModels;
using WebStoreApp.Interfaces.Services;
using WebStoreApp.Services.Mapping;

namespace WebStoreApp.Services.Products.InSQL
{
    public class SqlOrderService : IOrderService
    {
        private readonly WebStoreDB _db;
        private readonly UserManager<User> _UserManager;

        public SqlOrderService(WebStoreDB db, UserManager<User> UserManager)
        {
            _db = db;
            _UserManager = UserManager;
        }

        public async Task<OrderDTO> CreateOrder(string UserName, CreateOrderModel OrderModel)
        {
            var user = await _UserManager.FindByNameAsync(UserName);
            if (user is null)
            {
                throw new InvalidOperationException($"Пользователь {UserName} не найден");
            }

            await using var transaction = await _db.Database.BeginTransactionAsync();

            var order = new Order
            {
                Name = OrderModel.Order.Name,
                Phone = OrderModel.Order.Phone,
                Address = OrderModel.Order.Address,
                User = user,
                Date = DateTime.Now,
                Items = new List<OrderItem>()
            };

            foreach (var item in OrderModel.Items)
            {
                var product = await _db.Products.FindAsync(item.Id);
                if (product is null)
                {
                    throw new InvalidOperationException($"Товар {item.Id} не найден");
                }
                var order_item = new OrderItem
                {
                    Order = order,
                    Price = product.Price,
                    Quantity = item.Quantity,
                    Product = product
                };
                order.Items.Add(order_item);
            }

            await _db.Orders.AddAsync(order);
            await _db.SaveChangesAsync();
            await transaction.CommitAsync();

            return order.ToDTO();
        }

        public async Task<OrderDTO> GetOrderById(int id) => (await _db.Orders
            .Include(order => order.Items)
            .FirstOrDefaultAsync(order => order.Id == id))
            .ToDTO();

        public async Task<IEnumerable<OrderDTO>> GetUserOrders(string UserName) => (await _db.Orders
            .Include(order => order.User)
            .Include(order => order.Items)
            .Where(order => order.User.UserName == UserName)
            .ToArrayAsync())
            .Select(p=>p.ToDTO());
    }
}