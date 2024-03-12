using System.ComponentModel.DataAnnotations;

namespace Ecomerce.Models
{
	public class Product
	{
        [Key]
        public int? Product_Id { get; set; }
		[Required(ErrorMessage ="name is required")]
		[Display(Name="Product name")]
        public string? Product_name { set; get; }
		
		public string? Product_description { set; get; }

        public int? Product_rate { set; get; }

        public List<ProductCategoriy> Product_Categoriys { get; set; } = new List<ProductCategoriy>();
        public List<ProductSize> Product_sizes { get; set; } = new List<ProductSize>();
		public List<Style>? Product_styles { set; get; }
		public List<Block>? Product_blocks { set; get; }	

		
	}
}
