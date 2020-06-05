using WebStoreApp.Domain.Entities.Base.Interfaces;

namespace WebStoreApp.ViewModels
{
    public class BrandViewModel : INamedEntity, IOrderEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Order { get; set; }
    }
}
