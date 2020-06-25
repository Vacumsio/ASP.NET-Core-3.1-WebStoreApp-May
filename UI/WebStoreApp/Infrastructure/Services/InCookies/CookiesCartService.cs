using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStoreApp.Domain.Entities;
using WebStoreApp.Domain.Models;
using WebStoreApp.Domain.ViewModels;
using WebStoreApp.Infrastructure.Interfaces;
using WebStoreApp.Infrastructure.Mapping;

namespace WebStoreApp.Infrastructure.Services.InCookies
{
    public class CookiesCartService : ICartService
    {
        private readonly IProductData _ProductData;
        private readonly IHttpContextAccessor _IHttpContextAccessor;
        private readonly IMapper _Mapper;
        private readonly string _CartName;
        public CookiesCartService(IProductData ProductData, IHttpContextAccessor HttpContextAccessor, IMapper Mapper)
        {
            _ProductData = ProductData;
            _IHttpContextAccessor = HttpContextAccessor;
            _Mapper = Mapper;

            var user = HttpContextAccessor.HttpContext.User;
            var user_name = user.Identity.IsAuthenticated ? user.Identity.Name : null;
            _CartName = $"WebStoreApp[{user_name}]";
        }
        public Cart Cart
        {
            get
            {
                var context = _IHttpContextAccessor.HttpContext;
                var cookies = context.Response.Cookies;
                var cart_cookies = context.Request.Cookies[_CartName];
                if (cart_cookies is null)
                {
                    var cart = new Cart();
                    cookies.Append(_CartName, JsonConvert.SerializeObject(cart));
                    return cart;
                }
                ReplaceCookie(cookies, cart_cookies);
                return JsonConvert.DeserializeObject<Cart>(cart_cookies);
            }
            set => ReplaceCookie(_IHttpContextAccessor.HttpContext.Response.Cookies, JsonConvert.SerializeObject(value));
        }

        private void ReplaceCookie(IResponseCookies cookies, string cookie)
        {
            cookies.Delete(_CartName);
            cookies.Append(_CartName, cookie);
        }
        public void AddToCart(int id)
        {
            var cart = Cart;
            var item = cart.Items.FirstOrDefault(e => e.ProductId == id);
            if (item is null)
            {
                cart.Items.Add(new CartItem{ ProductId = id, Quantity = 1 });
            }
            else
            {
                item.Quantity++;
            }
            Cart = cart;
        }

        public void DecrementFromCart(int id)
        {
            var cart = Cart;
            var item = cart.Items.FirstOrDefault(e => e.ProductId == id);

            if (item is null)
            {
                return;
            }
            if (item.Quantity > 0) item.Quantity--;
            if (item.Quantity == 0) cart.Items.Remove(item);
        }

        public void RemoveAll()
        {
            var cart = Cart;
            cart.Items.Clear();
            Cart = cart;
        }

        public void RemoveFromCart(int id)
        {
            var cart = Cart;
            var item = cart.Items.FirstOrDefault(e => e.ProductId == id);

            if (item is null)
            {
                return;
            }

            cart.Items.Remove(item);

            Cart = cart;
        }

        public CartViewModel TransformFromCart()
        {
            var products = _ProductData.GetProducts(new ProductFilter {
            Ids = Cart.Items.Select(item => item.ProductId).ToArray()
            });;
            var product_viewmodel = products.Select(_Mapper.Map<ProductViewModel>).ToDictionary(p => p.Id);

            return new CartViewModel {
            Items = Cart.Items.Select(item => (product_viewmodel[item.ProductId],item.Quantity))
            };
        }
    }
}
