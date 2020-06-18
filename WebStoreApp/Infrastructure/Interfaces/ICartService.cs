using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStoreApp.ViewModels;

namespace WebStoreApp.Infrastructure.Interfaces
{
    interface ICartService
    {
        void AddToCart(int id);

        void DecrementFromCart(int id);
        void RemoveFromCart(int id);
        void RemoveAll();
        ProductViewModel TransformFromCart();
    }
}
