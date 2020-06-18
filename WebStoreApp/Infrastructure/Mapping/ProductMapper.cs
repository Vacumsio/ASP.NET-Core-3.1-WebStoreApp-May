using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStoreApp.Domain.Entities;
using WebStoreApp.ViewModels;

namespace WebStoreApp.Infrastructure.Mapping
{
    public static class ProductMapper
    {
        public static IEnumerable<ProductViewModel> ToView(this IEnumerable<Product> p) => p.Select(ToView);
        public static ProductViewModel ToView(this Product p) => new ProductViewModel
        {
            Id = p.Id,
            Name = p.Name,
            ImageUrl = p.ImageUrl,
            Order = p.Order,
            Price = p.Price,
        };

    }
}
