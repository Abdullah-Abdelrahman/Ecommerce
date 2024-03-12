namespace Ecomerce.Models
{
    public class ProductCategoriy
    {

        public int ProductId { get; set; }
        public Product product { get; set; } = default!;

        public int CategoriyId { get; set; }
        public Categoriy categoriy { get; set; } = default!;
    }
}
