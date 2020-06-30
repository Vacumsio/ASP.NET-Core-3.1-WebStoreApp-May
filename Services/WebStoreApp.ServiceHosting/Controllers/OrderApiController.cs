using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebStoreApp.Domain.DTO.Order;
using WebStoreApp.Interfaces.Services;

namespace WebStoreApp.ServiceHosting.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderApiController : ControllerBase, IOrderService
    {
        private readonly IOrderService _OrderService;

        public OrderApiController(IOrderService OrderService) => _OrderService = OrderService;

        [HttpPost("{UserName}")]
        public Task<OrderDTO> CreateOrder(string UserName,[FromBody] CreateOrderModel Model) => _OrderService.CreateOrder(UserName, Model);

        [HttpGet("{id}")]
        public Task<OrderDTO> GetOrderById(int id) => _OrderService.GetOrderById(id);
        [HttpGet("user/{UserName}")]
        public Task<IEnumerable<OrderDTO>> GetUserOrders(string UserName) => _OrderService.GetUserOrders(UserName);
    }
}
