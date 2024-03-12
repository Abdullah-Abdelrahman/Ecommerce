namespace Ecomerce.Models
{
    public class ProductSize
    {
        public int ProductId { get; set; }
        public Product product { get; set; } = default!;

        public int SizeId { get; set; }
        public Size size { get; set; } = default!;
    }
}
