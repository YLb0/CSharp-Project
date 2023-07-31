using Microsoft.EntityFrameworkCore;
using ProductSystem.Services.Data.Interfaces;
using Shop.System.Data;
using ShopSystem.Data.Models;
using ShopSystems.Web.ViewModels.Cart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductSystem.Services.Data
{
    public class BillService : IBillService
    {
        private readonly Sh0pDBContext dbContext;

        public BillService(Sh0pDBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task AddCartToBillAsync(string userId, AllProductsToCart product)
        {
            var alreadyADDED = await dbContext.Bills
               .AnyAsync(x => x.Cart.UserId.ToString() == userId && x.CartId.ToString() == product.Id);

            if (alreadyADDED == false)
            {
                var billi = new Bill()
                {
                    CartId = Guid.Parse(product.Id),
                    TotalPrice = product.TotalPrice,
                };
                await dbContext.Bills.AddAsync(billi);
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task<AllProductsToCart?> GetCartByIdAsync(string id)
        {
            return await dbContext.Carts
                .Where(x => x.Id.ToString() == id)
                .Select(p => new AllProductsToCart
                {
                    Id = p.Id.ToString(),
                    Name = p.Product.Name,
                    Price = p.Product.Price,
                    Quantity = p.Quantity,
                    ImageUrl = p.Product.ImageUrl,
                    Description = p.Product.Description,
                    Category = p.Product.Category.Name,
                }).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<AllProductsToCart>> GetMyBillAsync(string userId)
        {
            return await dbContext.Bills
                .Where(x => x.Cart.UserId.ToString() == userId)
        .Select(p => new AllProductsToCart
        {
            Id = p.CartId.ToString(),
            Name = p.Cart.Product.Name,
            Price = p.Cart.Product.Price,
            Quantity = p.Cart.Quantity,
            ImageUrl = p.Cart.Product.ImageUrl,
            Description = p.Cart.Product.Description,
            Category = p.Cart.Product.Category.Name
        }).ToListAsync();
        }
    }
}
