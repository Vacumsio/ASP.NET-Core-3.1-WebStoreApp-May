using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using WebStoreApp.DAL.Context;
using WebStoreApp.Domain.DTO;
using WebStoreApp.Domain.Entities;
using WebStoreApp.Interfaces.Services;
using WebStoreApp.Services.Mapping;

namespace WebStoreApp.Services.Products.InSQL
{
    public class SqlProductData : IProductData
    {
        private readonly WebStoreDB _db;
        public SqlProductData(WebStoreDB db) => _db = db;
        public IEnumerable<Brand> GetBrands() => _db.Brands;

        public ProductDTO GetProductById(int id) => _db.Products
            .Include(p => p.Brand)
            .Include(p => p.Section)
            .FirstOrDefault(p => p.Id == id)
            .ToDTO();

        public IEnumerable<ProductDTO> GetProducts(ProductFilter Filter = null)
        {
            IQueryable<Product> query = _db.Products
            .Include(p => p.Brand)
            .Include(p => p.Section);

            if (Filter?.Ids != null)
            {
                query = query.Where(product => Filter.Ids.Contains(product.Id));
            }
            if (Filter?.BrandId != null)
            {
                query = query.Where(product => product.BrandId == Filter.BrandId);
            }
            if (Filter?.SectionId != null)
            {
                query = query.Where(product => product.SectionId == Filter.SectionId);
            }
            return query.Select(p=>p.ToDTO());
        }

        public IEnumerable<Section> GetSections() => _db.Sections;
    }
}
