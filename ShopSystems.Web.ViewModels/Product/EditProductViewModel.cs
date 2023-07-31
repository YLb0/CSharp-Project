using ShopSystems.Web.ViewModels.Category;
using System.ComponentModel.DataAnnotations;

namespace ShopSystems.Web.ViewModels.Product
{
    public class EditProductViewModel
    {
        public EditProductViewModel()
        {
            Categories = new HashSet<AllCategoryViewModel>();
        }

        [Required]
        [StringLength(60)]
        public string Name { get; set; } = null!;

        public decimal Price { get; set; }

        [Required]
        public string ImageUrl { get; set; } = null!;

        [Required]
        [StringLength(300, MinimumLength = 3)]
        public string Description { get; set; } = null!;

        [Range(1, int.MaxValue)]
        public int CategoryId { get; set; }

        public IEnumerable<AllCategoryViewModel> Categories { get; set; }
    }
}
