using System;
using System.Collections.Generic;
using System.Text;
using WebStoreApp.Domain.Entities;

namespace WebStoreApp.Domain.ViewModels
{
    public class BreadCrumbsViewModel
    {
        public Section Section { get; set; }

        public Brand Brand { get; set; }

        public string Product { get; set; }
    }
}
