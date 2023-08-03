using System.ComponentModel.DataAnnotations;

namespace ShopSystem.Data.Models
{
    public class Client
    {
        public Client()
        {
            Id = Guid.NewGuid();
        }
        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        [StringLength(50)]
        public string Address { get; set; }

        [Required]
        [StringLength(50)]
        public string City { get; set; }

        [Required]
        [StringLength(50)]
        public string Country { get; set; }

        [Required]
        [StringLength(50)]
        public string PhoneNumber { get; set; }

        public DateTime OrderDate { get; set; }

        //public Guid BillId { get; set; }

        //[ForeignKey(nameof(BillId))]
        //public Bill Bill { get; set; }

        public List<BillsClients> BillsClients { get; set; } = new List<BillsClients>();
    }
}
