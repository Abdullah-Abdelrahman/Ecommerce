using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Ecomerce.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        [MaxLength(50)]
        public string OrderNumber { get; set; }
        [Required]
        public DateTime OrderDate { get; set; }
        public DateTime ShipDate { get; set; }
        public bool Deleted { get; set; }
        public bool Paid { get; set; }
        [Required]
        [MaxLength(50)]
        public int CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }
        public ICollection<OrderDetails> OrderDetails { get; set; }

    }
}
