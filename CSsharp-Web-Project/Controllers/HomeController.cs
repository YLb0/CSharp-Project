using Microsoft.AspNetCore.Mvc;
using ProductSystem.Services.Data.Interfaces;
using System.Diagnostics;

namespace CSsharp_Web_Project.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductService productService;
        private readonly ICategoryService categoryService;

        public HomeController(IProductService productService, ICategoryService categoryService)
        {
            this.productService = productService;
            this.categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
            var model = await productService.GetAllProductsAsync();

            return View(model);
        }
    }
}