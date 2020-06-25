using System.Collections.Generic;
using WebStoreApp.Domain.Entities.Base.Interfaces;

namespace WebStoreApp.Domain.ViewModels
{
    public class SectionViewModel : INamedEntity, IOrderEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Order { get; set; }
        public List<SectionViewModel> ChildSections { get; set; } = new List<SectionViewModel>();
        public SectionViewModel ParentSection { get; set; }
    }
}

