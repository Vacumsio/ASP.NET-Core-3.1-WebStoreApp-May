﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WebStoreApp.Domain.Entities.Base;
using WebStoreApp.Domain.Entities.Identity;

namespace WebStoreApp.Domain.Entities.Orders
{
    public class Order : NamedEntity
    {
        [Required]
        public virtual User User { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }

        public DateTime Date { get; set; }

        public virtual ICollection<OrderItem> Items { get; set; }
    }
}
