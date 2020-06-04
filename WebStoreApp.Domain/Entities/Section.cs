using WebStoreApp.Domain.Entities.Base;
using WebStoreApp.Domain.Entities.Base.Interfaces;

namespace WebStoreApp.Domain.Entities
{
    public class Section : NamedEntity, IOrderEntity
    {
        public int Order { get; set; }
        public int? ParentId { get; set; }
    }
}
