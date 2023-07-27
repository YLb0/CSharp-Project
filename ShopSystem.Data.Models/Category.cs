using System.ComponentModel.DataAnnotations;

namespace ShopSystem.Data.Models
{
    public class Category
    {
        public Category()
        {
            Products = new List<Product>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = null!;

        [Required]
        public bool IsActive { get; set; } = false;

        public virtual ICollection<Product> Products { get; set; }
    }
}
