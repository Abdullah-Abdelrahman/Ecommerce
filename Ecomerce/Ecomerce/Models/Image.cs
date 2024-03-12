using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Ecomerce.Models
{
    public class Image
    {
        [Key]
        public int? Image_Id { get; set; }
        public string? Image_url { get; set; }

        public int Style_Id { get; set; }
        [ForeignKey("Style_Id")]
        [JsonIgnore]
        public Style Style { get; set; }


    }
}
