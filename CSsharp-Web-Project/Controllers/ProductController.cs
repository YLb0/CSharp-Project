using Microsoft.AspNetCore.Mvc;
using OnlineSh0p.Web.Infrastructure.Extensions;
using ProductSystem.Services.Data.Interfaces;
using ShopSystems.Web.ViewModels.Product;

namespace CSsharp_Web_Project.Controllers
{
    public class ProductController : Controller
    {

        private readonly IProductService productService;
        private readonly ICategoryService categoryService;

        public ProductController(IProductService productService, ICategoryService categoryService)
        {
            this.productService = productService;
            this.categoryService = categoryService;
        }

        public async Task<IActionResult> All()
        {
            if (!this.User.IsAdmin())
            {
                return RedirectToAction("Index", "Home");
            }
            var model = await productService.GetAllProductsAsync();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            if (!this.User.IsAdmin())
            {
                return RedirectToAction(nameof(All));
            }
            var model = await productService.GetNewAddProductModelAsync();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddProductViewModel model)
        {
            if (ModelState.IsValid == false)
            {
                return View(model);
            }
            
            if (!this.User.IsAdmin())
            {
                return RedirectToAction(nameof(All));
            }
            await productService.AddProductAsync(model);

            return RedirectToAction(nameof(All));

        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            if (!this.User.IsAdmin())
            {
                return RedirectToAction(nameof(All));
            }
            try
            {
                var product = await this.productService
                            .GetProductByIDForEditAsync(id);

                // product.Categories = await categoryService.GetAllCategoryAsync();

                return this.View(product);
            }
            catch (Exception)
            {
                return RedirectToAction(nameof(All));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string id, EditProductViewModel model)
        {
            if (!ModelState.IsValid)
            {
                //model.Categories = await this.categoryService.GetAllCategoryAsync();
                return View(model);
            }

            if (!this.User.IsAdmin())
            {
                return RedirectToAction(nameof(All));
            }

            try
            {

                await productService.EditProductAsync(id, model);
            }
            catch (Exception)
            {
                //this.ModelState.AddModelError(string.Empty, "Unexpected error Plese try again !!");

                // model.Categories = await this.categoryService.GetAllCategoryAsync();

                return this.View(model);
            }

            return this.RedirectToAction(nameof(All));
        }

        //[HttpGet]
        //public async Task<IActionResult> Delete(string id)
        //{
        //    try
        //    {
        //        ProductPreDelete model=
        //            await this.productService.GetProductForDeleteByIdAsync(id);

        //        return View(model);
        //    }
        //    catch (Exception)
        //    {
        //        return RedirectToAction(nameof(All));
        //    }
        //}

        [HttpPost]
        public async Task<IActionResult> Delete(string id, ProductPreDeleteViewModel model)
        {
            if (!this.User.IsAdmin())
            {
                return RedirectToAction(nameof(All));
            }

            try
            {
                await productService.DeleteProductAsync(id);

                return RedirectToAction(nameof(All));
            }
            catch (Exception)
            {
                return RedirectToAction(nameof(All));
            }

        }
    }
}
