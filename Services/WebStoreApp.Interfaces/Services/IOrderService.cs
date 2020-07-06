using System.Collections.Generic;
using System.Threading.Tasks;
using WebStoreApp.Domain.DTO.Order;
using WebStoreApp.Domain.ViewModels;

namespace WebStoreApp.Interfaces.Services
{
    public interface IOrderService
    {
        Task<OrderDTO> CreateOrder(string UserName, CreateOrderModel Model);
        Task<IEnumerable<OrderDTO>> GetUserOrders(string UserName);

        Task<OrderDTO> GetOrderById(int id);
    }
}
