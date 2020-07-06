using WebStoreApp.Domain.Entities.Base.Interfaces;

namespace WebStoreApp.Domain.DTO
{
    public class SectionDTO : INamedEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
