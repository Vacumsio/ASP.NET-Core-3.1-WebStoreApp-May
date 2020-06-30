using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStoreApp.Domain.DTO;
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

        public static ProductDTO ToDTO(this Product p) => p is null ? null : new ProductDTO
        {
            Id = p.Id,
            Name = p.Name,
            Order = p.Order,
            Price = p.Price,
            ImageUrl = p.ImageUrl,
            Brand = p.Brand.ToDTO(),
            Section = p.Section.ToDTO(),
        };

        public static Product FromDTO(this ProductDTO p) => p is null ? null : new Product
        {
            Id = p.Id,
            Name = p.Name,
            Order = p.Order,
            Price = p.Price,
            ImageUrl = p.ImageUrl,
            BrandId = p.Brand?.Id,
            Brand = p.Brand.FromDTO(),
            Section = p.Section.FromDTO(),
        };
    }
}
