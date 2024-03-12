using Ecomerce.Models;

namespace Ecomerce.SeessionModels
{
    public class BlockWithFile
    {

        public Block block { get; set; }
        public IFormFile? File { get; set; }
    }
}
