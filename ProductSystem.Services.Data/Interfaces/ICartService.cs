using ShopSystems.Web.ViewModels.Cart;
using ShopSystems.Web.ViewModels.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductSystem.Services.Data.Interfaces
{
    public interface ICartService
    {
        Task<ProductViewModel?> GetProductByIdAsync(string id);

        Task AddProductToCartAsync(string userId, ProductViewModel product);

        Task<IEnumerable<AllProductsToCart>> GetMyProductsAsync(string userId);

        Task RemoveProductFromCartAsync(string userId);
    }
}
