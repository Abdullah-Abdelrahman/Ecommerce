using System.ComponentModel.DataAnnotations;

namespace Ecomerce.Models
{
    public class Size
    {
        [Key]
        public int? SizeID { get; set; }
        public int size { get; set; }
        //public List<Product> Products { get; set; }
		

	}

   
}
