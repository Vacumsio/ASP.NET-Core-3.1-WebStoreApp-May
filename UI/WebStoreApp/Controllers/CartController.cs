using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using WebStoreApp.Domain.DTO.Order;
using WebStoreApp.Domain.ViewModels;
using WebStoreApp.Interfaces.Services;

namespace WebStoreApp.Controllers
{
    public class CartController : Controller
    {
        #region CTOR
        private readonly ICartService _CartService;
        public CartController(ICartService CartService) => _CartService = CartService;
        #endregion

        public IActionResult Details() => View(new CartOrderViewModel
        {
            Cart = _CartService.TransformFromCart(),
            Order = new OrderViewModel()
        });

        #region Methods in that case if JS is not loaded
        public IActionResult AddToCart(int id)
        {
            _CartService.AddToCart(id);
            return RedirectToAction(nameof(Details));
        }

        public IActionResult DecrementFromCart(int id)
        {
            _CartService.DecrementFromCart(id);
            return RedirectToAction(nameof(Details));
        }

        public IActionResult RemoveFromCart(int id)
        {
            _CartService.RemoveFromCart(id);
            return RedirectToAction(nameof(Details));
        }
        public IActionResult RemoveAll()
        {
            _CartService.RemoveAll();
            return RedirectToAction(nameof(Details));
        }
        #endregion

        [HttpPost]
        public async Task<IActionResult> Checkout(OrderViewModel Model, [FromServices] IOrderService OrderService)
        {
            if (!ModelState.IsValid)
            {
                return View(nameof(Details), new CartOrderViewModel
                {
                    Cart = _CartService.TransformFromCart(),
                    Order = Model
                });
            }

            var order_model = new CreateOrderModel
            {
                Order = Model,
                Items = _CartService.TransformFromCart().Items
                    .Select(item => new OrderItemDTO
                    {
                        Id = item.Product.Id,
                        Price = item.Product.Price,
                        Quantity = item.Quantity
                    })
                    .ToList()
            };

            var order = await OrderService.CreateOrder(User.Identity.Name, order_model);

            _CartService.RemoveAll();

            return RedirectToAction(nameof(OrderConfirmed), new { id = order.Id });
        }
        public IActionResult OrderConfirmed(int id)
        {
            ViewBag.OrderId = id;
            return View();
        }


        #region WebApi methods for JS
        public IActionResult GetCartView() => ViewComponent("Cart");

        public IActionResult AddToCartAPIi(int id)
        {
            _CartService.AddToCart(id);
            return Json(new {id, message = $"Товар id:{id} был отправлен в корзину" });
        }

        public IActionResult DecrementFromCartAPI(int id)
        {
            _CartService.DecrementFromCart(id);
            return Ok();
        }

        public IActionResult RemoveFromCartAPI(int id)
        {
            _CartService.RemoveFromCart(id);
            return Ok();
        }
        public IActionResult RemoveAllAPI()
        {
            _CartService.RemoveAll();
            return Ok();
        }
        #endregion
    }
}
