using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStoreApp.Domain.Entities.Orders;
using WebStoreApp.Domain.ViewModels;

namespace WebStoreApp.Infrastructure.Interfaces
{
    public interface IOrderService
    {
        Task<Order> CreateOrder(string UserName,CartViewModel Cart, OrderViewModel Order);
        Task<IEnumerable<Order>> GetUserOrders(string UserName);

        Task<Order> GetOrderById(int id);
    }
}
