using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebStoreApp.Domain.Entities.Identity
{
    public class User: IdentityUser
    {
        public const string Admin = "Admin";
        public const string Password = "Pass";
    }
}
