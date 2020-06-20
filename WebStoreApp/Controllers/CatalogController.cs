using System.Linq;
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

        public IActionResult Shop(int? SectionId, int? BrandId)
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
                .ToView()
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

            return View(product.ToView());
        }

        public IActionResult CheckOut() => View();

        public IActionResult Cart() => View();

        public IActionResult Login() => View();
    }
}
