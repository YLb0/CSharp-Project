using ShopSystems.Web.ViewModels.Cart;
using ShopSystems.Web.ViewModels.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductSystem.Services.Data.Interfaces
{
    public interface IClientService
    {
        Task AddClient(AddClientViewModel model);

        Task<AllProductsToCart?> GetBillByIdAsync(string id);

        Task<ClientViewModel?> GetClientByIdAsync(string id);

        Task AddOrder(AllProductsToCart billId, ClientViewModel clientId);

        Task<IEnumerable<AllOrdersViewModel>> GetMyOrdersAsync();
    }
}
