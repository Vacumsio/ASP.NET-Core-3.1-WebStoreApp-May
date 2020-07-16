using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SimpleMvcSitemap;
using WebStoreApp.Interfaces.Services;

namespace WebStoreApp.Controllers
{
    public class SitemapController : Controller
    {
        public IActionResult Index([FromServices] IProductData ProductData)
        {
            var nodes = new List<SitemapNode>
            {
                new SitemapNode(Url.Action("Index", "Home")),
                new SitemapNode(Url.Action("Index", "ContactUs")),
                new SitemapNode(Url.Action("Blog", "Blog")),
                new SitemapNode(Url.Action("BlogSingle", "Blog")),
                new SitemapNode(Url.Action("Shop", "Catalog")),
                new SitemapNode(Url.Action("Index", "WebApiTest")),
            };

            nodes.AddRange(ProductData.GetSections().Select(section => new SitemapNode(Url.Action("Shop", "Catalog", new { SectionId = section.Id }))));

            foreach (var brand in ProductData.GetBrands())
                nodes.Add(new SitemapNode(Url.Action("Shop", "Catalog", new { BrandId = brand.Id })));

            foreach (var product in ProductData.GetProducts())
                nodes.Add(new SitemapNode(Url.Action("Details", "Catalog", new { product.Id })));

            return new SitemapProvider().CreateSitemap(new SitemapModel(nodes));
        }
    }
}