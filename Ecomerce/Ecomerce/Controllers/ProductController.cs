using Ecomerce.Data;
using Ecomerce.Models;
using Ecomerce.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace Ecomerce.Controllers
{
    public class ProductController : Controller
    {
        private readonly SystemContext systemContext;

        public ProductController(SystemContext _systemContext)
        {
            systemContext = _systemContext;
        }
        public IActionResult getProductByIdAndStyleId(int id,int sid)
        {

            var product = systemContext.ProductList.Where(x => x.Product_Id == id);
            product = product.Include(x => x.Product_styles).ThenInclude(s => s.Style_images);
            product = product.Include(x => x.Product_blocks);
            product = product.Include(x => x.Product_sizes).ThenInclude(s => s.size);
            List<Product> p = product.ToList();
            ProductStyleIndexViewModel viewModel = new ProductStyleIndexViewModel();
            viewModel.product = p[0];viewModel.sid = sid;   
            return View(viewModel);
        }
    }
}
