using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStoreApp.Data;
using WebStoreApp.Domain.Entities;
using WebStoreApp.Infrastructure.Interfaces;

namespace WebStoreApp.Infrastructure.Services
{
    public class InMemoryProductData : IProductData
    {
        public IEnumerable<Brand> GetBrands() => TestData.Brands;

        public IEnumerable<Section> GetSections() => TestData.Sections;
      
        public IEnumerable<Product> GetProducts(ProductFilter Filter = null)
        {
            var query = TestData.Products;
            if (Filter?.SectionId!=null)
            {
                query = query.Where(section => section.SectionId == Filter.SectionId);
            }
            if (Filter?.BrandId != null)
            {
                query = query.Where(brand => brand.SectionId == Filter.BrandId);
            }
            return query;
        }
    }
}
