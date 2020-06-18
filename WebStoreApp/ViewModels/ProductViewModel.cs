using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStoreApp.Domain.Entities;
using WebStoreApp.Domain.Entities.Base.Interfaces;

namespace WebStoreApp.ViewModels
{
    public class ProductViewModel : INamedEntity, IOrderEntity
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public int Order { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }
        public string Brand { get; set; }
    }
}
