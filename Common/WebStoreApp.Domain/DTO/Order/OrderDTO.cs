﻿using System;
using System.Collections.Generic;
using System.Text;
using WebStoreApp.Domain.Entities.Base;
using WebStoreApp.Domain.Entities.Base.Interfaces;

namespace WebStoreApp.Domain.DTO.Order
{
    public class OrderDTO : INamedEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }

        public DateTime Date { get; set; }

        public IEnumerable<OrderItemDTO> Items { get; set; }

    }
}
