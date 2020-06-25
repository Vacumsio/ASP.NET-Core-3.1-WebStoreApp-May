using System.ComponentModel.DataAnnotations;
using WebStoreApp.Domain.Entities.Base.Interfaces;

namespace WebStoreApp.Domain.Entities.Base
{
    public class NamedEntity: BaseEntity, IBaseEntity
    {
        [Required]
        public string Name { get; set; }
    }
}
