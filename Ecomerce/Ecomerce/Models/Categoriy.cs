using System.ComponentModel.DataAnnotations;

namespace Ecomerce.Models
{
	public class Categoriy
	{
        [Key]
        public int? Categoriy_Id { get; set; }
		public string Categoriy_Name { get; set; }
		public string Categoriy_Description { get; set; }
		//public List<Product> Products { get; set; }

	}
}
