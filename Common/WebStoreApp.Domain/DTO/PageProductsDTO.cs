using System;
using System.Collections.Generic;
using System.Text;

namespace WebStoreApp.Domain.DTO
{
    public class PageProductsDTO
    {
        public IEnumerable<ProductDTO> Products { get; set; }

        public int TotalCount { get; set; }
    }
}
