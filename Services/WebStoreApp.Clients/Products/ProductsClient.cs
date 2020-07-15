using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Net.Http;
using WebStoreApp.Clients.Base;
using WebStoreApp.Domain;
using WebStoreApp.Domain.DTO;
using WebStoreApp.Domain.Entities;
using WebStoreApp.Interfaces.Services;

namespace WebStoreApp.Clients.Products
{
    public class ProductsClient : BaseClient, IProductData
    {
        public ProductsClient(IConfiguration Configuration) : base(Configuration, WebApi.Products) { }

        public IEnumerable<Section> GetSections() => Get<IEnumerable<Section>>($"{_ServiceAddress}/sections");

        public IEnumerable<Brand> GetBrands() => Get<IEnumerable<Brand>>($"{_ServiceAddress}/brands");

        public IEnumerable<ProductDTO> GetProducts(ProductFilter Filter = null) =>
            Post(_ServiceAddress, Filter ?? new ProductFilter())
               .Content
               .ReadAsAsync<IEnumerable<ProductDTO>>()
               .Result;

        public ProductDTO GetProductById(int id) => Get<ProductDTO>($"{_ServiceAddress}/{id}");

        public Section GetSection(int id) => Get<Section>($"{_ServiceAddress}/section/{id}");

        public Brand GetBrand(int id) => Get<Brand>($"{_ServiceAddress}/brand/{id}");
    }
}
