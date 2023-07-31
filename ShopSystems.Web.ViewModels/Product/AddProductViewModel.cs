using ShopSystems.Web.ViewModels.Category;
using System.ComponentModel.DataAnnotations;

namespace ShopSystems.Web.ViewModels.Product
{
    public class AddProductViewModel
    {
        [Required]
        [StringLength(60)]
        public string Name { get; set; } = null!;

        public decimal Price { get; set; }

        [Required]
        public string ImageUrl { get; set; } = null!;

        [Required]
        [StringLength(300, MinimumLength = 2)]
        public string Description { get; set; } = null!;

        public int CategoryId { get; set; }

        public IEnumerable<AllCategoryViewModel> Categories { get; set; } = new List<AllCategoryViewModel>();
    }
}
