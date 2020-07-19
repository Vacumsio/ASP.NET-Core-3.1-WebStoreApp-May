using System.Collections.Generic;
using System.Linq;
using WebStoreApp.Domain.DTO;
using WebStoreApp.Domain.Entities;
using WebStoreApp.Interfaces.Services;
using WebStoreApp.Services.Data;
using WebStoreApp.Services.Mapping;

namespace WebStoreApp.Services.Products.InMemory
{
    public class InMemoryProductData : IProductData
    {
        public IEnumerable<Brand> GetBrands() => TestData.Brands;

        public IEnumerable<Section> GetSections() => TestData.Sections;

        public PageProductsDTO GetProducts(ProductFilter Filter = null)
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

            var total_count = query.Count();

            if (Filter?.PageSize > 0)
                query = query
                   .Skip((Filter.Page - 1) * (int)Filter.PageSize)
                   .Take((int)Filter.PageSize);

            return new PageProductsDTO
            {
                Products = query.Select(p => p.ToDTO()),
                TotalCount = total_count
            };
        }

        public ProductDTO GetProductById(int id) => TestData.Products.FirstOrDefault(e => e.Id == id).ToDTO();

        public Section GetSection(int id) => TestData.Sections.FirstOrDefault(e => e.Id == id);

        public Brand GetBrand(int id) => TestData.Brands.FirstOrDefault(e => e.Id == id);
    }
}
