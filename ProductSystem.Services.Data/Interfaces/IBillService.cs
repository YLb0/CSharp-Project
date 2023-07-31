using ShopSystems.Web.ViewModels.Cart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductSystem.Services.Data.Interfaces
{
    public interface IBillService
    {
        Task AddCartToBillAsync(string userId, AllProductsToCart cart);

        Task<AllProductsToCart?> GetCartByIdAsync(string cartId);

        Task<IEnumerable<AllProductsToCart>> GetMyBillAsync(string userId);
    }
}
