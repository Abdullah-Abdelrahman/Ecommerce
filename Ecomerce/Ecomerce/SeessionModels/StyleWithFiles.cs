using Ecomerce.Models;

namespace Ecomerce.SeessionModels
{
    public class StyleWithFiles
    {
        public Style? style { get; set; }

        public List<FileOfImage>? files { get; set; }
    }

    public class FileOfImage
    {
       public IFormFile? file { get; set; }
    }
}
