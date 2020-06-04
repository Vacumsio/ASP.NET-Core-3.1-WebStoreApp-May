using System.Collections.Generic;

namespace WebStoreApp.ViewModels
{
    public class ShopViewModel
    { 
        public int? BrandId { get; set; }
        public int? SectionId { get; set; }
        public IEnumerable<ProductViewModel> Products { get; set; }
    }
}
