using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductSystem.Services.Data.Interfaces;
using System.Security.Claims;

namespace CSsharp_Web_Project.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        private readonly ICartService cartService;

        public CartController(ICartService cartService)
        {
            this.cartService = cartService;
        }

        public async Task<IActionResult> AddToCart(string id)
        {
            var product = await cartService.GetProductByIdAsync(id);

            if (product == null)
            {
                return RedirectToAction(nameof(MyCart));
            }
            if (!ModelState.IsValid)
            {
                return View();
            }

            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            // var userEmail = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;

            try
            {
                await cartService.AddProductToCartAsync(userId, product);

                return RedirectToAction(nameof(MyCart));
            }
            catch (Exception)
            {
                return RedirectToAction(nameof(MyCart));
            }
        }

        public async Task<IActionResult> MyCart()
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            try
            {
                var model = await cartService.GetMyProductsAsync(userId);

                return View(model);
            }
            catch (Exception)
            {
                return RedirectToAction("All", "Products");
            }
        }

        [HttpPost]
        public async Task<IActionResult> RemoveFromCart(string id)
        {
            // var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            try
            {
                await cartService.RemoveProductFromCartAsync(id);

                return RedirectToAction(nameof(MyCart));
            }
            catch (Exception)
            {
                return RedirectToAction(nameof(MyCart));
            }

        }
    }
}
