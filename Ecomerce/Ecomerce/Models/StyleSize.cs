using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecomerce.Models
{
	public class StyleSize
	{
        
        public int quantity { set; get; }

		public int? StyleId { get; set; }
		[ForeignKey("StyleId")]
		public Style Style { get; set; }

        
        public int? SizeId { get; set; }
        [ForeignKey("SizeId")]

        public Size size { set; get; }

	}
}
