using System;
using System.Collections.Generic;
using System.Text;
using WebStoreApp.Domain.DTO;
using WebStoreApp.Domain.Entities;

namespace WebStoreApp.Services.Mapping
{
    public static class BrandMapper
    {
        public static BrandDTO ToDTO(this Brand Brand) => Brand is null ? null : new BrandDTO
        {
            Id = Brand.Id,
            Name = Brand.Name,
        };

        public static Brand FromDTO(this BrandDTO Brand) => Brand is null ? null : new Brand
        {
            Id = Brand.Id,
            Name = Brand.Name,
        };
    }
}
