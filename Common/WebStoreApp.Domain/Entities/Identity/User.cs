using Microsoft.AspNetCore.Identity;

namespace WebStoreApp.Domain.Entities.Identity
{
    public class User: IdentityUser
    {
        public const string Administrator = "Admin";
        public const string Password = "Pass";
    }
}
