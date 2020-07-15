using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebStoreApp.Domain;
using WebStoreApp.Domain.DTO;
using WebStoreApp.Domain.Entities;
using WebStoreApp.Interfaces.Services;

namespace WebStoreApp.ServiceHosting.Controllers
{
    [Route(WebApi.Products)]
    [ApiController]
    public class ProductsApiController : ControllerBase, IProductData
    {
        private readonly IProductData _ProductData;
        public ProductsApiController(IProductData ProductData) => _ProductData = ProductData;

        [HttpGet("{id}")]
        public ProductDTO GetProductById(int id) => _ProductData.GetProductById(id);

        [HttpPost]
        public IEnumerable<ProductDTO> GetProducts([FromBody] ProductFilter Filter = null) => _ProductData.GetProducts(Filter);

        [HttpGet("sections")]
        public IEnumerable<Section> GetSections() => _ProductData.GetSections();
        [HttpGet("section/{id}")]
        public Section GetSection(int id) => _ProductData.GetSection(id);

        [HttpGet("brands")]
        public IEnumerable<Brand> GetBrands() => _ProductData.GetBrands();
        [HttpGet("brand /{id}")]
        public Brand GetBrand(int id) => _ProductData.GetBrand(id);
    }



}
