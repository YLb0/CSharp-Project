using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopSystem.Data.Models
{
    public class Bill
    {
        public Bill()
        {
            Id = Guid.NewGuid();
        }
        [Key]
        public Guid Id { get; set; }

        public Guid CartId { get; set; }

        [ForeignKey(nameof(CartId))]
        public virtual Cart Cart { get; set; }

        public decimal TotalPrice { get; set; }

        public List<BillsClients> BillsClients { get; set; } = new List<BillsClients>();
    }
}
