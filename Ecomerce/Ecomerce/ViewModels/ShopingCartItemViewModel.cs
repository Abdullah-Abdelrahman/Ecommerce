namespace Ecomerce.ViewModels
{
    public class ShopingCartItemViewModel
    {
        
        public int productId { get; set; }
        public int StyleId { get; set; }
        public int sizeId { get; set; }
        public string ImageUrl { get; set; }
        public int Size {  get; set; }
        public string productName { get; set; }
        public string StyleName { get; set; }
        public int quantity { get; set; }
        public decimal price { get; set; }
        public string Discount { get; set; }
        public decimal Total {  get; set; }
    }
}
