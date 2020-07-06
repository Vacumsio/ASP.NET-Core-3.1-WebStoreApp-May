using Microsoft.AspNetCore.Identity;
using WebStoreApp.Domain.Entities.Identity;

namespace WebStoreApp.Interfaces.Services.Identity
{
    public interface IRolesClient : IRoleStore<Role> { }
    
}
