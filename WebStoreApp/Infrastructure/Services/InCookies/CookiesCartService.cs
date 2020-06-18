using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStoreApp.Infrastructure.Interfaces;
using WebStoreApp.Models;
using WebStoreApp.ViewModels;

namespace WebStoreApp.Infrastructure.Services.InCookies
{
    public class CookiesCartService : ICartService
    {
        private readonly IProductData _ProductData;
        private readonly IHttpContextAccessor _IHttpContextAccessor;
        private readonly string _CartName;
        public CookiesCartService(IProductData ProductData, IHttpContextAccessor IHttpContextAccessor)
        {
            _ProductData = ProductData;
            _IHttpContextAccessor = IHttpContextAccessor;
        }
        public Cart Cart
        {
            get
            {

            }
            set
            {

            }
        }
        public void AddToCart(int id)
        {
            throw new NotImplementedException();
        }

        public void DecrementFromCart(int id)
        {
            throw new NotImplementedException();
        }

        public void RemoveAll()
        {
            throw new NotImplementedException();
        }

        public void RemoveFromCart(int id)
        {
            throw new NotImplementedException();
        }

        public ProductViewModel TransformFromCart()
        {
            throw new NotImplementedException();
        }
    }
}
