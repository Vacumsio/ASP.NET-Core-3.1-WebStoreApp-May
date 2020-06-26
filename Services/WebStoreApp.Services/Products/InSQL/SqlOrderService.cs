using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStoreApp.DAL.Context;
using WebStoreApp.Domain.Entities.Identity;
using WebStoreApp.Domain.Entities.Orders;
using WebStoreApp.Domain.ViewModels;
using WebStoreApp.Interfaces.Services;

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

        public async Task<Order> CreateOrder(string UserName, CartViewModel Cart, OrderViewModel OrderModel)
        {
            var user = await _UserManager.FindByNameAsync(UserName);
            if (user is null)
            {
                throw new InvalidOperationException($"льзователь {UserName} не найден");
            }

            await using var transaction = await _db.Database.BeginTransactionAsync();

            var order = new Order
            {
                Name = OrderModel.Name,
                Phone = OrderModel.Phone,
                Address = OrderModel.Address,
                User = user,
                Date = DateTime.Now,
                Items = new List<OrderItem>()
            };

            foreach (var (product_model, quantity) in Cart.Items)
            {
                var product = await _db.Products.FindAsync(product_model.Id);
                if (product is null)
                {
                    throw new InvalidOperationException($"Товар {product_model.Id} не найден");
                }
                var order_item = new OrderItem
                {
                    Order = order,
                    Price = product.Price,
                    Quantity = quantity,
                    Product = product
                };
                order.Items.Add(order_item);
            }

            await _db.Orders.AddAsync(order);
            await _db.SaveChangesAsync();
            await transaction.CommitAsync();

            return order;
        }

        public Task<Order> GetOrderById(int id) => _db.Orders
            .Include(order => order.Items)
            .FirstOrDefaultAsync(order => order.Id == id);

        public async Task<IEnumerable<Order>> GetUserOrders(string UserName) => await _db.Orders
            .Include(order => order.User)
            .Include(order => order.Items)
            .Where(order => order.User.UserName == UserName)
            .ToArrayAsync();
    }
}
