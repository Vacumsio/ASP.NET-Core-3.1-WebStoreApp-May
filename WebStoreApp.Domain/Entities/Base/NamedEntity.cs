using WebStoreApp.Domain.Entities.Base.Interfaces;

namespace WebStoreApp.Domain.Entities.Base
{
    public class NamedEntity: BaseEntity, IBaseEntity
    {
        public string Name { get; set; }
    }
}
