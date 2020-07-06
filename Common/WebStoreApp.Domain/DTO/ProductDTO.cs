using WebStoreApp.Domain.Entities.Base.Interfaces;

namespace WebStoreApp.Domain.DTO
{
    public class ProductDTO : INamedEntity, IOrderEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Order { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public BrandDTO Brand { get; set; }
        public SectionDTO Section { get; set; }
    }
}
