using Ecomerce.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Ecomerce.ViewModels
{
    public class FirstPartOfFormOfProductViewModel
    {

        [Required(ErrorMessage = "name is required")]
        [Display(Name = "Product name")]
        public string? Product_name { set; get; }

        public string? Product_description { set; get; }

        public int? Product_rate { set; get; }

        public IEnumerable<SelectListItem> Categories { set; get; }=Enumerable.Empty<SelectListItem>();
        public List<int>? Product_Categoriys { set; get; }= new List<int>();
     
        public List<int>? Product_sizes { set; get; }=new List<int>();
        public IEnumerable<SelectListItem> Sizes { set; get; } = Enumerable.Empty<SelectListItem>();
    }
}
