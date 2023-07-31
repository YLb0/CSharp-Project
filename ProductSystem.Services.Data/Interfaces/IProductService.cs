using ShopSystems.Web.ViewModels.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductSystem.Services.Data.Interfaces
{
    public interface IProductService
    {
        Task AddProductAsync(AddProductViewModel model);

        Task<IEnumerable<AllProductsViewModel>> GetAllProductsAsync();

        Task<AddProductViewModel> GetNewAddProductModelAsync();

        Task<EditProductViewModel?> GetProductByIDForEditAsync(string productID);

        Task EditProductAsync(string id, EditProductViewModel model);

        Task DeleteProductAsync(string id);

        Task<ProductPreDeleteViewModel> GetProductForDeleteByIdAsync(string id);
    }
}
