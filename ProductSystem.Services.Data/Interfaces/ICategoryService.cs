using ShopSystems.Web.ViewModels.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductSystem.Services.Data.Interfaces
{
    public interface ICategoryService
    {
        Task AddCategoryAsync(AddCategoryViewModel model);

        Task<IEnumerable<AllCategoryViewModel>> GetAllCategoryAsync();

        Task<AddCategoryViewModel?> GetCategoryByIDForEditAsync(int categoryID);

        Task DeleteCategoryAsync(string id);

        Task EditCategoryAsync(AddCategoryViewModel model, int id);

        Task<IEnumerable<string>> AllCategoryNameAsync();
    }
}
