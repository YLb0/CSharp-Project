using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopSystem.Data.Models
{
    public class BillsClients
    {
        public Guid ClientId { get; set; }

        public virtual Client Client { get; set; }

        public Guid BillId { get; set; }

        public virtual Bill Bill { get; set; }
    }
}
