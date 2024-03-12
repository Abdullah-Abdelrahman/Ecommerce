using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Ecomerce.Models
{
	public class Style
	{
        [Key]
        public int? Style_Id { get; set; }

        public string? Style_name { set; get; }
        public int? Style_price { set; get; }
		public List<Image>? Style_images { set; get; }

        public List<StyleSize> StyleSizes;

        public int Product_Id { get; set; }
        [ForeignKey("Product_Id")]
        public Product Product { get; set; }


    }
}
