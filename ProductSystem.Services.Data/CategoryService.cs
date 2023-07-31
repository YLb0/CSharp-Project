using Microsoft.EntityFrameworkCore;
using ProductSystem.Services.Data.Interfaces;
using Shop.System.Data;
using ShopSystem.Data.Models;
using ShopSystems.Web.ViewModels.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductSystem.Services.Data
{
    public class CategoryService : ICategoryService
    {
        private readonly Sh0pDBContext dbContext;

        public CategoryService(Sh0pDBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task AddCategoryAsync(AddCategoryViewModel model)
        {
            Category category = new Category
            {
                Name = model.Name,
            };

            await dbContext.Categories.AddAsync(category);
            await dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<string>> AllCategoryNameAsync()
        {
            IEnumerable<string> allNames = await this.dbContext
                .Categories
                .Select(c => c.Name)
                .ToArrayAsync();

            return allNames;
        }

        public async Task DeleteCategoryAsync(string id)
        {
            var categoryToDelete = await dbContext.
                Categories.Where(p => p.IsActive == false)
                .FirstAsync(h => h.Id.ToString() == id);

            categoryToDelete.IsActive = true;

            await dbContext.SaveChangesAsync();
        }

        public async Task EditCategoryAsync(AddCategoryViewModel model, int id)
        {
            var category = await dbContext.Categories.FindAsync(id);

            if (category != null)
            {
                category.Name = model.Name;
                category.IsActive = false;

                await dbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<AllCategoryViewModel>> GetAllCategoryAsync()
        {
            IEnumerable<AllCategoryViewModel> allCategories =
                await this.dbContext
                .Categories
                //.AsNoTracking()
                .Where(x => x.IsActive == false)
                .Select(c => new AllCategoryViewModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    IsActive = c.IsActive
                }).ToListAsync();

            return allCategories;
        }

        public async Task<AddCategoryViewModel?> GetCategoryByIDForEditAsync(int categoryID)
        {
            return await dbContext.Categories
                .Where(c => c.Id == categoryID)
                .Select(c => new AddCategoryViewModel
                {
                    Name = c.Name,
                }).FirstOrDefaultAsync();
        }
    }
}
