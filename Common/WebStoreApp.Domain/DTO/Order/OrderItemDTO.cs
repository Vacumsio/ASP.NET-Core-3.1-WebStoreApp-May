using System;
using System.Collections.Generic;
using System.Text;
using WebStoreApp.Domain.Entities.Base.Interfaces;

namespace WebStoreApp.Domain.DTO.Order
{
    public class OrderItemDTO : IBaseEntity
    {
        public int Id { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }
    }
}
