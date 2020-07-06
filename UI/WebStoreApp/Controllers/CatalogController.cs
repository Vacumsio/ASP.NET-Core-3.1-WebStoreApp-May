using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebStoreApp.Domain.Entities;
using WebStoreApp.Domain.ViewModels;
using WebStoreApp.Interfaces.Services;
using WebStoreApp.Services.Mapping;

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
                .Select(p=>p.FromDTO())
                .Select(Mapper.Map<ProductViewModel>)
                .OrderBy(p => p.Order)
            });
        }

        public IActionResult Details(int id)
        {
            var product = _ProductData.GetProductById(id);
            if (product is null)
            {
                NotFound();
            }

            return View((product.FromDTO().ToView()));
        }

        public IActionResult CheckOut() => View();

        public IActionResult Cart() => View();

        public IActionResult Login() => View();
    }
}
