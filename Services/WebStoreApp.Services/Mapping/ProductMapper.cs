using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStoreApp.Domain.Entities;
using WebStoreApp.Domain.ViewModels;

namespace WebStoreApp.Services.Mapping
{
    public static class ProductMapper
    {

        public static ProductViewModel ToView(this Product p) => new ProductViewModel
        {
            Id = p.Id,
            Name = p.Name,
            ImageUrl = p.ImageUrl,
            Order = p.Order,
            Price = p.Price,
            Brand = p.Brand?.Name,
        };

        public static IEnumerable<ProductViewModel> ToView(this IEnumerable<Product> p) => p.Select(ToView);

    }
}
