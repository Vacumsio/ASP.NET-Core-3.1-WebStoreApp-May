﻿using System;
using System.Collections.Generic;
using System.Text;

namespace WebStoreApp.Domain.Entities
{
    public class ProductFilter
    {
        public int? SectionId { get; set; }

        public int? BrandId { get; set; }

        public int[] Ids { get; set; }
    }
}
