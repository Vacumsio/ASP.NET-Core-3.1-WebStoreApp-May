using System;
using System.Collections.Generic;
using System.Text;

namespace WebStoreApp.Domain.ViewModels
{
    public class SelectableSectionsViewModel
    {
        public IEnumerable<SectionViewModel> Sections { get; set; }

        public int? CurrentSectionId { get; set; }

        public int? ParentSectionId { get; set; }
    }
}
