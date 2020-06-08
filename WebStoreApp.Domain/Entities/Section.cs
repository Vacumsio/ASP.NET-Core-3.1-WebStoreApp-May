using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using WebStoreApp.Domain.Entities.Base;
using WebStoreApp.Domain.Entities.Base.Interfaces;

namespace WebStoreApp.Domain.Entities
{
    [Table("ProductSection")]
    public class Section : NamedEntity, IOrderEntity
    {
        public int Order { get; set; }

        public int? ParentId { get; set; }

        [ForeignKey(nameof(ParentId))]
        public virtual Section ParentSection { get; set; }

        public virtual ICollection<Product> Products { get; set; }

    }
}
