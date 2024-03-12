using Ecomerce.Data;
using Ecomerce.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ecomerce.Controllers
{
    public class CollectionsController : Controller
    {
 
        
        private readonly SystemContext systemContext;

        public CollectionsController(SystemContext _systemContext) {
            systemContext = _systemContext;
        }
        public IActionResult AllCollections()
        {
			var products = systemContext.ProductList.Select(x=>x);
			products = products.Include(x => x.Product_Categoriys);
			products = products.Include(x => x.Product_styles).ThenInclude(z => z.Style_images);
			products = products.Include(x => x.Product_sizes).ThenInclude(s => s.size);
			products = products.Include(x => x.Product_blocks);

			List<StyleSize> style_size_quantities = systemContext.StyleSizes.ToList();
			return View((List<Product>)products.ToList());


        }
        public IActionResult NewCollections()
        {
            var products = systemContext.ProductList.Where(x=>x.Product_Categoriys.Any(c=>c.categoriy.Categoriy_Name=="new"));
            products = products.Include(x => x.Product_Categoriys);
			products = products.Include(x => x.Product_styles).ThenInclude(z=>z.Style_images);
			products = products.Include(x => x.Product_sizes).ThenInclude(s => s.size); 
			products = products.Include(x => x.Product_blocks);
			
			List<StyleSize> style_size_quantities = systemContext.StyleSizes.ToList();
            return View((List<Product>)products.ToList());
        }

        public IActionResult MenCollections()
        {

			var products = systemContext.ProductList.Where(x => x.Product_Categoriys.Any(c => c.categoriy.Categoriy_Name == "Men"));
			products = products.Include(x => x.Product_Categoriys);
			products = products.Include(x => x.Product_styles).ThenInclude(z => z.Style_images);
			products = products.Include(x => x.Product_sizes).ThenInclude(s => s.size);
			products = products.Include(x => x.Product_blocks);

			List<StyleSize> style_size_quantities = systemContext.StyleSizes.ToList();
			return View((List<Product>)products.ToList());
		}

        public IActionResult WomenCollections()
        {

			var products = systemContext.ProductList.Where(x => x.Product_Categoriys.Any(c => c.categoriy.Categoriy_Name == "Women"));
			products = products.Include(x => x.Product_Categoriys);
			products = products.Include(x => x.Product_styles).ThenInclude(z => z.Style_images);
			products = products.Include(x => x.Product_sizes).ThenInclude(s => s.size);
			products = products.Include(x => x.Product_blocks);

			List<StyleSize> style_size_quantities = systemContext.StyleSizes.ToList();
			return View((List<Product>)products.ToList());
		}
    }
}
