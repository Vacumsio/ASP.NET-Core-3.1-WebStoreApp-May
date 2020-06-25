using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebStoreApp.Domain.Entities.Base.Interfaces;

namespace WebStoreApp.Domain.Entities.Base
{
    public abstract class BaseEntity : IBaseEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
    }
}
