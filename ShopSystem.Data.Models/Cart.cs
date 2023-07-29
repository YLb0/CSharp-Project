using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopSystem.Data.Models
{
    public class Cart
    {
        public Cart()
        {
            Id = Guid.NewGuid();
        }
        [Key]
        public Guid Id { get; set; }

        public Guid ProductId { get; set; }

        public virtual Product Product { get; set; }

        public Guid UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public bool IsActive { get; set; } = false;

        [StringLength(1000)]
        public int Quantity { get; set; }

        public decimal TotalPrice { get; set; }
    }
}
