using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebStoreApp.Domain.Entities;
using WebStoreApp.Infrastructure.Interfaces;
using WebStoreApp.Infrastructure.Mapping;
using WebStoreApp.ViewModels;

namespace WebStoreApp.Controllers
{
    public class CatalogController : Controller
    {
        private readonly IProductData _ProductData;

        public CatalogController(IProductData ProductData) => _ProductData = ProductData;

        public IActionResult Shop(int? SectionId, int? BrandId, [FromServices] IMapper Mapper)
        {
            var filter = new ProductFilter
            {
                SectionId = SectionId,
                BrandId = BrandId
            };

            var products = _ProductData.GetProducts(filter);

            return View(new CatalogViewModel
            {
                SectionId = SectionId,
                BrandId = BrandId,
                Products = products
                .Select(Mapper.Map<ProductViewModel>)
                .OrderBy(p => p.Order)
            });
        }

        public IActionResult Details(int id, [FromServices] IMapper Mapper)
        {
            var product = _ProductData.GetProductById(id);
            if (product is null)
            {
                NotFound();
            }

            return View(Mapper.Map<ProductViewModel>(product));
        }

        public IActionResult CheckOut() => View();

        public IActionResult Cart() => View();

        public IActionResult Login() => View();
    }
}
