using System;
using System.Collections.Generic;
using System.Text;
using WebStoreApp.Domain.ViewModels;

namespace WebStoreApp.Domain.DTO.Order
{
    public class CreateOrderModel
    {
        public OrderViewModel Order { get; set; }

        public List<OrderItemDTO> Items { get; set; }
    }
}
