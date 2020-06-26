using System.Collections.Generic;
using System.Linq;
using WebStoreApp.Domain.Entities;
using WebStoreApp.Interfaces.Services;
using WebStoreApp.Services.Data;

namespace WebStoreApp.Services.Products.InMemory
{
    public class InMemoryProductData : IProductData
    {
        public IEnumerable<Brand> GetBrands() => TestData.Brands;

        public IEnumerable<Section> GetSections() => TestData.Sections;

        public IEnumerable<Product> GetProducts(ProductFilter Filter = null)
        {
            var query = TestData.Products;
            if (Filter?.SectionId != null)
            {
                query = query.Where(product => product.SectionId == Filter.SectionId);
            }
            if (Filter?.BrandId != null)
            {
                query = query.Where(product => product.BrandId == Filter.BrandId);
            }
            return query;
        }

        public Product GetProductById(int id) => TestData.Products.FirstOrDefault(e => e.Id == id);
    }
}
