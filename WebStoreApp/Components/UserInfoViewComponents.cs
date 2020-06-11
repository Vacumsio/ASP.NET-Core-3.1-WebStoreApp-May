using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebStoreApp.Components
{
    public class UserInfoViewComponents: ViewComponent
    {
        public IViewComponentResult Invoke() 
            => User
            .Identity?
            .IsAuthenticated == true 
            ? View("UserInfo") 
            : View();
    }
}
