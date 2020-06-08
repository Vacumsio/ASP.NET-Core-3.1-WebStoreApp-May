using System.ComponentModel.DataAnnotations.Schema;
using WebStoreApp.Domain.Entities.Base;
using WebStoreApp.Domain.Entities.Base.Interfaces;

namespace WebStoreApp.Domain.Entities
{
    [Table("ProductBrand")]
    public class Brand: NamedEntity, IOrderEntity
    {
        public int Order { get; set; }
    }
}
