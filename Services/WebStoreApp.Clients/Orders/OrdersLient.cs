using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebStoreApp.Clients.Base;
using WebStoreApp.Domain;
using WebStoreApp.Domain.DTO.Order;
using WebStoreApp.Interfaces.Services;

namespace WebStoreApp.Clients.Orders
{
    public class OrdersClient : BaseClient, IOrderService
    {
        public OrdersClient(IConfiguration Configuration) : base(Configuration, WebApi.Orders) { }

        public Task<OrderDTO> CreateOrder(string UserName, CreateOrderModel Model) => throw new NotImplementedException();

        public Task<OrderDTO> GetOrderById(int id) => throw new NotImplementedException();

        public Task<IEnumerable<OrderDTO>> GetUserOrders(string UserName) => throw new NotImplementedException();
    }
}
