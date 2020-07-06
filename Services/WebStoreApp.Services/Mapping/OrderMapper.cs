using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebStoreApp.Domain.DTO.Order;
using WebStoreApp.Domain.Entities.Orders;

namespace WebStoreApp.Services.Mapping
{
    public static class OrderMapper
    {
        public static OrderDTO ToDTO(this Order Order) => Order is null ? null : new OrderDTO
        {
            Id = Order.Id,
            Phone = Order.Phone,
            Address = Order.Address,
            Date = Order.Date,
            Items = Order.Items.Select(ToDTO)
        };

        public static OrderItemDTO ToDTO(this OrderItem Item) => Item is null ? null : new OrderItemDTO
        {
            Id = Item.Id,
            Price = Item.Price,
            Quantity = Item.Quantity
        };

        public static Order FromDTO(this OrderDTO Order) => Order is null ? null : new Order
        {
            Id = Order.Id,
            Phone = Order.Phone,
            Address = Order.Address,
            Date = Order.Date,
            Items = Order.Items.Select(FromDTO).ToArray()
        };

        public static OrderItem FromDTO(this OrderItemDTO Item) => Item is null ? null : new OrderItem
        {
            Id = Item.Id,
            Price = Item.Price,
            Quantity = Item.Quantity
        };
    }
}
