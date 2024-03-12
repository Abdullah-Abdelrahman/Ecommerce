using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecomerce.Models
{
    public class OrderDetails
    {
        [Key]
        public int OrderDetailsId { get; set; }

        public int OrderId { get; set; }
        [ForeignKey("OrderId")]
        public Order Order { get; set; }

        public int ProductId { get; set; }
      
        public int StyleId { get; set; }
  
        public int SizeId { get; set; }
       
        [Required]
        public decimal Price { get; set; }
        [Required]
        public int Quantity { get; set; }
        public decimal Discount { get; set; }
        [Required]
        public decimal Total {  get; set; }


    }
}
