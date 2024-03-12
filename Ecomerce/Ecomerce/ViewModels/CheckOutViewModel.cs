
using Ecomerce.Models;

namespace Ecomerce.ViewModels
{
    public class CheckOutViewModel
    {

        public Customer? customer { get; set; }
        public List<ShopingCartItemViewModel>? shopings { get; set; }
    }
}
