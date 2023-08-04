using Microsoft.AspNetCore.Mvc;
using ProductSystem.Services.Data.Interfaces;

namespace CSsharp_Web_Project.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductService productService;

        public HomeController(IProductService productService)
        {
            this.productService = productService;
        }

        public async Task<IActionResult> Index()
        {
            var model = await productService.GetAllProductsAsync();

            return View(model);
        }
    }
}