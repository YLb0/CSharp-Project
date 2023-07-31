using Microsoft.AspNetCore.Mvc;
using ProductSystem.Services.Data.Interfaces;
using ShopSystems.Web.ViewModels.Category;
using ShopSystems.Web.ViewModels.Product;

namespace CSsharp_Web_Project.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        public async Task<IActionResult> All()
        {
            var model = await categoryService.GetAllCategoryAsync();

            return View(model);
        }

        [HttpGet]
        public IActionResult Add()
        {
            AddCategoryViewModel model = new AddCategoryViewModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddCategoryViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await categoryService.AddCategoryAsync(model);

            return RedirectToAction(nameof(All));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id, ProductPreDeleteViewModel model)
        {
            try
            {
                await categoryService.DeleteCategoryAsync(id);

                return RedirectToAction(nameof(All));
            }
            catch (Exception)
            {
                return RedirectToAction(nameof(All));
            }

        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            AddCategoryViewModel? category = await categoryService.GetCategoryByIDForEditAsync(id);

            if (category == null)
            {
                return RedirectToAction(nameof(All));
            }

            return View(category);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, AddCategoryViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await categoryService.EditCategoryAsync(model, id);

            return RedirectToAction(nameof(All));
        }
    }
}
