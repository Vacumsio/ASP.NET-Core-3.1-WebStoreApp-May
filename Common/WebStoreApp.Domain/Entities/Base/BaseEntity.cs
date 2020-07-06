using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebStoreApp.Domain.Entities.Base.Interfaces;

namespace WebStoreApp.Domain.Entities.Base
{
    /// <summary>Базовая сущность</summary>
    public abstract class BaseEntity : IBaseEntity
    {
        /// <summary>Идентификатор</summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
    }
}
