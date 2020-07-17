using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStoreApp.Domain.DTO;
using WebStoreApp.Domain.Entities;

namespace WebStoreApp.Interfaces.Services
{
    public interface IProductData
    {
        IEnumerable<Section> GetSections();
        Section GetSection(int id);
        IEnumerable<Brand> GetBrands();
        Brand GetBrand(int id);
        PageProductsDTO GetProducts(ProductFilter Filter = null);
        ProductDTO GetProductById(int id);
    }
}
