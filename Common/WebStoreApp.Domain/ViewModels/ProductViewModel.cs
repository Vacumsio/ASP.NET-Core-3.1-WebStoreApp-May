﻿using WebStoreApp.Domain.Entities.Base.Interfaces;

namespace WebStoreApp.Domain.ViewModels
{
    public class ProductViewModel : INamedEntity, IOrderEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Order { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }
        public string Brand { get; set; }
    }
}
