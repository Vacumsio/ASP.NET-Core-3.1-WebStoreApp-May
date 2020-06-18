using Microsoft.AspNetCore.Identity;

namespace WebStoreApp.Domain.Entities.Identity
{
    public class Role: IdentityRole
    {
        public const string Administrator = "Password";
        public const string User = "Password";
    }
}
