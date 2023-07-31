using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopSystems.Web.ViewModels.Product
{
    public class ProductViewModel
    {
        public string Id { get; set; } = null!;

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Name { get; set; } = null!;

        public decimal Price { get; set; }

        [Required]
        public string ImageUrl { get; set; } = null!;

        [Required]
        [StringLength(400, MinimumLength = 8)]
        public string Description { get; set; } = null!;

        public int CategoryId { get; set; }
    }
}
