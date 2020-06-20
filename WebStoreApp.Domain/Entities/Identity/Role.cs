using Microsoft.AspNetCore.Identity;

namespace WebStoreApp.Domain.Entities.Identity
{
    public class Role: IdentityRole
    {
        public const string Administrator = "Administrators";
        public const string User = "Users";
    }
}
