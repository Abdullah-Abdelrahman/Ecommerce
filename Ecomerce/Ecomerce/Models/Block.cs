using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Ecomerce.Models
{
	public class Block
	{
		[Key]
		public int? Block_Id { get; set; }
		[Required]
		public string? Block_title { get; set; }
	
		public string? Block_description { get; set; }
	
		public string? Block_image { get; set; }
        public int Product_Id { get; set; }
        [ForeignKey("Product_Id")]
        public Product Product { get; set; }
		
	}
}
