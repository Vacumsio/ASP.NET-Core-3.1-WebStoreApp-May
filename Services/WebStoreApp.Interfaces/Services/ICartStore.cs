using WebStoreApp.Domain.Models;

namespace WebStoreApp.Interfaces.Services
{
    public interface ICartStore
    {
        Cart Cart { get; set; }
    }
}
