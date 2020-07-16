﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStoreApp.Domain.ViewModels;
using WebStoreApp.Interfaces.Services;

namespace WebStoreApp.Components
{
    public class BreadCrumbsViewComponent : ViewComponent
    {
        private readonly IProductData _ProductData;
        public BreadCrumbsViewComponent(IProductData ProductData) => _ProductData = ProductData;

        public IViewComponentResult Invoke()
        {
            var model = new BreadCrumbsViewModel();

            if (int.TryParse(Request.Query["SectionId"].ToString(),out var section_id))
                model.Section = _ProductData.GetSection(section_id);

            if (int.TryParse(Request.Query["BrandId"].ToString(), out var brand_id))
                model.Brand = _ProductData.GetBrand(brand_id);

            if(int.TryParse(ViewContext.RouteData.Values["id"]?.ToString(), out var product_id))
            {
                var product = _ProductData.GetProductById(product_id);
                if (product!=null)
                {
                    model.Product = product.Name;
                }
            }

            return View(model);
        }
    }
}
