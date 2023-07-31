using Microsoft.EntityFrameworkCore;
using ProductSystem.Services.Data.Interfaces;
using Shop.System.Data;
using ShopSystem.Data.Models;
using ShopSystems.Web.ViewModels.Cart;
using ShopSystems.Web.ViewModels.Product;

namespace ProductSystem.Services.Data
{
    public class CartService : ICartService
    {
        private readonly Sh0pDBContext dbContext;

        public CartService(Sh0pDBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task AddProductToCartAsync(string userId, ProductViewModel product)
        {
            var alreadyADDED = await dbContext.Carts
                .AnyAsync(ub => ub.UserId.ToString() == userId && ub.ProductId.ToString() == product.Id);

            var prod = await dbContext.Carts
                        .FirstOrDefaultAsync(ub => ub.ProductId.ToString() == product.Id && ub.UserId.ToString() == userId);

            if (alreadyADDED == false)
            {
                var cartt = new Cart()
                {
                    ProductId = Guid.Parse(product.Id),
                    UserId = Guid.Parse(userId),
                    Quantity = 1,
                    IsActive = false
                };
                await dbContext.Carts.AddAsync(cartt);
            }
            else
            {
                if (prod.IsActive == true)
                {
                    prod.Quantity = 1;
                    //prod.TotalPrice += product.Price;
                    prod.IsActive = false;
                }
                else
                {
                    prod.Quantity += 1;
                    prod.TotalPrice += product.Price;
                }
            }
            await dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<AllProductsToCart>> GetMyProductsAsync(string userId)
        {
            return await dbContext.Carts
                .Where(u => u.UserId.ToString() == userId && u.IsActive == false)
                .Select(p => new AllProductsToCart
                {
                    Name = p.Product.Name,
                    Id = p.Id.ToString(),
                    Category = p.Product.Category.Name,
                    Price = p.Product.Price,
                    Quantity = p.Quantity,
                    // TotalPrice=p.TotalPrice,
                    Description = p.Product.Description,
                    ImageUrl = p.Product.ImageUrl
                }).ToListAsync();
        }

        public async Task<ProductViewModel?> GetProductByIdAsync(string id)
        {
            return await dbContext.Products
                .Where(b => b.Id.ToString() == id)
                .Select(b => new ProductViewModel
                {
                    Id = b.Id.ToString(),
                    Name = b.Name,
                    Price = b.Price,
                    ImageUrl = b.ImageUrl,
                    Description = b.Description,
                    CategoryId = b.CategoryId
                }).FirstOrDefaultAsync();

        }

        public async Task RemoveProductFromCartAsync(string userId)
        {
            var cartToDelete = await dbContext.
                    Carts.Where(p => p.IsActive == false)
                    .FirstAsync(p => p.Id.ToString() == userId);

            cartToDelete.IsActive = true;

            await dbContext.SaveChangesAsync();
        }
    }
}
