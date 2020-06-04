using System;
using System.Collections.Generic;
using System.Text;
using WebStoreApp.Domain.Entities.Base;
using WebStoreApp.Domain.Entities.Base.Interfaces;

namespace WebStoreApp.Domain.Entities
{
    public class Product : NamedEntity, IOrderEntity
    {
        public int Order { get; set; }

        public int SectionId { get; set; }

        public int? BrandId { get; set; }

        public string ImageUrl { get; set; }

        public decimal Price { get; set; }
    }
}
