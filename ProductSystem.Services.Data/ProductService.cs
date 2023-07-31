using Microsoft.EntityFrameworkCore;
using ProductSystem.Services.Data.Interfaces;
using Shop.System.Data;
using ShopSystem.Data.Models;
using ShopSystems.Web.ViewModels.Category;
using ShopSystems.Web.ViewModels.Product;

namespace ProductSystem.Services.Data
{
    public class ProductService : IProductService
    {
        private readonly Sh0pDBContext dbContext;

        public ProductService(Sh0pDBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task AddProductAsync(AddProductViewModel model)
        {
            Product product = new Product
            {
                Name = model.Name,
                Price = model.Price,
                ImageUrl = model.ImageUrl,
                Description = model.Description,
                CategoryId = model.CategoryId,
            };

            await dbContext.Products.AddAsync(product);
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteProductAsync(string id)
        {
            var houseToDelete = await dbContext.
                Products.Where(p => p.IsActive == false)
                .FirstAsync(h => h.Id.ToString() == id);

            houseToDelete.IsActive = true;

            await dbContext.SaveChangesAsync();
        }

        public async Task EditProductAsync(string id, EditProductViewModel model)
        {
            Product product = await this.dbContext
                .Products
                .Where(p => p.IsActive == false)
                .FirstAsync(p => p.Id.ToString() == id);


            product.Name = model.Name;
            product.Price = model.Price;
            product.ImageUrl = model.ImageUrl;
            product.Description = model.Description;
            product.CategoryId = model.CategoryId;

            await dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<AllProductsViewModel>> GetAllProductsAsync()
        {
            return await dbContext
                .Products
                .Where(p => p.IsActive == false)
                .Select(p => new AllProductsViewModel
                {
                    Id = p.Id.ToString(),
                    Name = p.Name,
                    ImageUrl = p.ImageUrl,
                    Price = p.Price,
                    Description = p.Description,
                    Category = p.Category.Name
                }).ToArrayAsync();
        }

        public async Task<AddProductViewModel> GetNewAddProductModelAsync()
        {
            var category = await dbContext.Categories
                .Where(x => x.IsActive == false)
                .Select(c => new AllCategoryViewModel
                {
                    Name = c.Name,
                    Id = c.Id,
                }).ToListAsync();
            var model = new AddProductViewModel
            {
                Categories = category
            };
            return model;
        }

        public async Task<EditProductViewModel?> GetProductByIDForEditAsync(string id)
        {
            var categories = await dbContext.Categories
                .Where(x => x.IsActive == false)
                .Select(c => new AllCategoryViewModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    IsActive = c.IsActive
                }).ToListAsync();

            return await dbContext.
                Products
                .Where(p => p.Id.ToString() == id)
                .Select(p => new EditProductViewModel
                {
                    Name = p.Name,
                    Price = p.Price,
                    Description = p.Description,
                    ImageUrl = p.ImageUrl,
                    CategoryId = p.CategoryId,
                    Categories = categories
                }).FirstOrDefaultAsync();
        }

        public async Task<ProductPreDeleteViewModel> GetProductForDeleteByIdAsync(string id)
        {
            Product product = await this.dbContext
                .Products
                .Where(h => h.IsActive == false)
                .FirstAsync(h => h.Id.ToString() == id);

            return new ProductPreDeleteViewModel
            {
                Name = product.Name,
                Price = product.Price,
                Description = product.Description,
                ImageUrl = product.ImageUrl
            };
        }
    }
}
