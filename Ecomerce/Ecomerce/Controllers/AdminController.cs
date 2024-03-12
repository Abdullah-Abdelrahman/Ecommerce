using Ecomerce.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ecomerce.Data;
using Ecomerce.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
//these 2 libarariys are for working with an file 
using System.IO;
using Microsoft.AspNetCore.Hosting;
using static System.Reflection.Metadata.BlobBuilder;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using Ecomerce.SeessionModels;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authorization;
using System.Linq;

namespace Ecomerce.Controllers
{

   [Authorize(Roles ="Admin,Owner")]
   public class AdminController : Controller
   {

      
       private readonly IWebHostEnvironment _webHost;
       private readonly SystemContext systemContext;

        public AdminController(IWebHostEnvironment webHost,SystemContext _systemContext)
        {

           _webHost = webHost;
            systemContext = _systemContext;
        }
        //first fase in create
       [HttpGet]
       public IActionResult AddProductGenerall()
       {
           
           FirstPartOfFormOfProductViewModel firstPart = new FirstPartOfFormOfProductViewModel() { };

           firstPart.Categories = systemContext.Categorias.Select(x => new SelectListItem() { Value = x.Categoriy_Id.ToString(), Text = x.Categoriy_Name }).ToList();
           firstPart.Sizes = systemContext.Sizes.Select(x => new SelectListItem() { Value = x.SizeID.ToString(), Text = x.size.ToString() }).ToList();

           return View(firstPart);
       }

       [HttpPost]
       public IActionResult AddProductGenerall(FirstPartOfFormOfProductViewModel firstPart)
       {
           if (true)
           {
             string serialized = JsonConvert.SerializeObject(firstPart);
             HttpContext.Session.SetString("generalInfo", serialized);

             return RedirectToAction("SetBlocks");
           }

           return View(firstPart);
       }


        // second faze in create

       [HttpGet]
       public IActionResult SetBlocks()
       {


          List<BlockWithFile> blocks = new List<BlockWithFile>();
          
          blocks.Insert(0, new BlockWithFile { block=new Block()});

          return View(blocks);
       }
       [HttpPost]
       public IActionResult SetBlocks(List<BlockWithFile> blocks)
       {
          


           foreach (var block in blocks)
           {

                if (block.File != null && block.File.Length > 0)
                {
                
                
                    string uniqueFileName = GetUploadedFileName(block.File);
                    if (uniqueFileName != null && uniqueFileName != "")
                    {
                        block.block.Block_image = uniqueFileName;
                    }
                
                }


           }

           if (blocks[0].block.Block_description == null)
           {

              
               return View(blocks);
           }
           else
           {
               string serialized = JsonConvert.SerializeObject(blocks.Select(x => x.block));
               HttpContext.Session.SetString("blocks", serialized);
               return RedirectToAction("SetStyles");
           }


       }

        //third faze in create
       [HttpGet]
       public IActionResult SetStyles()
       {
   
           List<StyleWithFiles> styles = new List<StyleWithFiles>();
           styles.Insert(0, new StyleWithFiles {style=new Style { },files=new List<FileOfImage>() });
           styles[0].style.Style_images = new List<Image>();
           styles[0].style.Style_images.Insert(0, new Image { });
           IFormFile? file = null;
           styles[0].files.Insert(0,new FileOfImage());

       return View(styles);
       }
       [HttpPost]
       public IActionResult SetStyles(List<StyleWithFiles> styles)
       {

       
          
           foreach (var style in styles)
           {

                for(int i= 0; i< style?.files?.Count() ; i++)
                {

                    if (style?.files?[i] != null && style?.files[i].file?.Length >0)
                    {


                        string uniqueFileName = GetUploadedFileName(style.files[i].file);
                        if (uniqueFileName != null && uniqueFileName != "")
                        {
                           style.style.Style_images[i].Image_url = uniqueFileName;
                        }

                    }
                }
               

           }

           if (true)
           {
           // Store the serialized styles in session
               string serialized = JsonConvert.SerializeObject(styles.Select(x=>x.style));
               HttpContext.Session.SetString("styles", serialized);
            
               return RedirectToAction("SetQuntatiy");
           }
           return View(styles);
       }

        // fourth fase in create
       [HttpGet]
       public IActionResult SetQuntatiy()
       {
            FirstPartOfFormOfProductViewModel general= JsonConvert.DeserializeObject<FirstPartOfFormOfProductViewModel>(HttpContext.Session.GetString("generalInfo"));


            List<Size> sizes = new List<Size>();
            foreach (var siz in general?.Product_sizes)
            {
                sizes.Add(systemContext.Sizes.Single(x => x.SizeID == siz));
            }

            List<Style> styles=JsonConvert.DeserializeObject<List<Style>>(HttpContext.Session.GetString("styles"));



            List<StyleSize> quantatis = new List<StyleSize>();
           for (int i = 0; i < styles?.Count(); i++)
           {
               for (int j = 0; j < sizes?.Count(); j++)
               {
                    StyleSize item = new StyleSize();
                    item.Style = styles[i];
                    item.size= sizes[j];
                    item.SizeId = sizes[j].SizeID;
                  
                    item.quantity = 0;
                    quantatis.Add(item);
               }
           }

          
           return View(quantatis);
       }
        [HttpPost]
        public IActionResult SetQuntatiy(List<StyleSize> quantatis)
        {

            string serialized = JsonConvert.SerializeObject(quantatis);
            HttpContext.Session.SetString("quantatis", serialized);
           Console.WriteLine(serialized);
            return RedirectToAction("create");
            
        }

        //the last fase in create => Add to data base
        [HttpGet]
        public IActionResult create()
        {
            Product product = new Product();
            FirstPartOfFormOfProductViewModel generalInfo = JsonConvert.DeserializeObject<FirstPartOfFormOfProductViewModel>(HttpContext.Session.GetString("generalInfo"));

            List<Block>blocks= JsonConvert.DeserializeObject<List<Block>>(HttpContext.Session.GetString("blocks"));

            List<Style>styles= JsonConvert.DeserializeObject<List<Style>>(HttpContext.Session.GetString("styles"));
          
            if (generalInfo == null || blocks == null || styles == null)
            {
                return RedirectToAction("Error");
            }

            product.Product_name = generalInfo?.Product_name;
            product.Product_description = generalInfo?.Product_description;
            product.Product_rate= generalInfo?.Product_rate;

            

            product.Product_Categoriys = generalInfo?.Product_Categoriys.Select(x => new ProductCategoriy() { CategoriyId = x }).ToList();
           
            
            product.Product_sizes= generalInfo?.Product_sizes.Select(x => new ProductSize() { SizeId = x }).ToList();

           
            product.Product_blocks=blocks;
            product.Product_styles=styles;


            string serialized = JsonConvert.SerializeObject(product);
            HttpContext.Session.SetString("product", serialized);

           
            product.Product_sizes = generalInfo?.Product_sizes.Select(x => new ProductSize() { SizeId = x ,size=systemContext.Sizes.Where(s=>s.SizeID==x).FirstOrDefault()}).ToList();

            
            return View(product);
        }

        [HttpPost]
        public IActionResult create(Product product)
        {
            product = JsonConvert.DeserializeObject<Product>(HttpContext.Session.GetString("product"));
           
            systemContext.ProductList.Add(product);
            systemContext.SaveChanges();


            //List<Style> styles = new List<Style>();
            //styles = systemContext.ProductList.OrderBy(p=>p.Product_Id).Last().Product_styles;
            //List<StyleSize> quantatis = JsonConvert.DeserializeObject<List<StyleSize>>(HttpContext.Session.GetString("quantatis"));
            //foreach (var styleSize in quantatis)
            //{
            //    // Find the Style associated with the StyleSize
            //    var style = styles.FirstOrDefault(s => s.Style_name == styleSize.Style.Style_name);
            //    if (style != null)
            //    {
            //        // Assign the found Style to the StyleSize
            //        styleSize.Style = style;
                    

            //    }
            //    styleSize.StyleId = null;
            //    styleSize.SizeId = null;
            //}
            //Console.WriteLine("..............................");

            //string serialized = JsonConvert.SerializeObject(quantatis);
            
            //Console.WriteLine(serialized);
            //systemContext.StyleSizes.AddRange(quantatis);
            //systemContext.SaveChanges();
            return RedirectToAction("Products");
        }


        //Create an file for the image and creat an uniqe name for it
        private string GetUploadedFileName(IFormFile? imgfile)
        {
           string uniqueFileName = null;

           if (imgfile != null)
           {
               string uploadsFolder = Path.Combine(_webHost.WebRootPath, "images");
               uniqueFileName = Guid.NewGuid().ToString() + "_" + imgfile.FileName;
               string filePath = Path.Combine(uploadsFolder, uniqueFileName);
               using (var fileStream = new FileStream(filePath, FileMode.Create))
               {
                  imgfile.CopyTo(fileStream);
               }
           }
           return uniqueFileName;
        }

        //Clear unused Image from storage
        public void CleanUnUsedImages()
        {

            List<string> images = systemContext.Images.Select(x => x.Image_url).Concat(systemContext.Blocks.Select(x => x.Block_image)).ToList();
          
            try
            {
                string[] files = Directory.GetFiles(Path.Combine(_webHost.WebRootPath, "images"));
                foreach (string file in files)
                {
                    string filename = Path.GetFileName(file);
                    if (!images.Contains(filename))
                    {
                       
                        System.IO.File.Delete(file);
                        Console.WriteLine($"Removed: {file}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

        }

        //Admin product page
        public IActionResult Products()
        {
          
            var products = systemContext.ProductList.Select(x => x);
            products = products.Include(x => x.Product_Categoriys);
            products = products.Include(x => x.Product_styles).ThenInclude(z => z.Style_images);
            products = products.Include(x => x.Product_sizes).ThenInclude(s => s.size);
            products = products.Include(x => x.Product_blocks);

            List<StyleSize> style_size_quantities = systemContext.StyleSizes.ToList();
            return View((List<Product>)products.ToList());
            return View();
        }
        //Owner HR page to manage the roles and staff
        [Authorize(Roles ="Owner")]
        public IActionResult HR()
        {
            return View();
        }

        public IActionResult Orders()
        {
            
            List<Order> orders = systemContext.orders
    .Include(o => o.OrderDetails)
    .ToList();

            return View(orders);
        }

        public IActionResult Customers()
        {
            List<Customer> customers = systemContext.customers.Select(x => x).ToList();
            return View(customers);
        }

        /// <summary>
        /// <<  UPDATE SECTION  >>
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>


        public IActionResult Update(int Product_Id)
        {
          

            var product = systemContext.ProductList
                             .Where(x => x.Product_Id == Product_Id)
                             ?.Include(x => x.Product_styles).ThenInclude(s => s.Style_images)
                             .Include(x => x.Product_blocks)
                             .Include(x => x.Product_sizes).ThenInclude(s => s.size)
                             .FirstOrDefault();
            Product p = product;
           
            
            return View(p);
        }


        [HttpPost]
        public IActionResult UpdateGeneral(Product product)
        {
            
            var existingProduct =systemContext.ProductList.FirstOrDefault(x=>x.Product_Id==product.Product_Id);
            
            if (existingProduct != null)
            {

                // Update the properties of the existing Product
                existingProduct.Product_name = product.Product_name;
                existingProduct.Product_description = product.Product_description;
                existingProduct.Product_rate = product.Product_rate;
               
                systemContext.SaveChanges();
            }


            return RedirectToAction("Update",new { Product_Id = product.Product_Id });
        }


        [HttpGet]
        public IActionResult UpdateBlock(int Block_Id)
        {

            var block = systemContext.Blocks.Find(Block_Id);
            return Json(block);
        }
        [HttpPost]
        public IActionResult UpdateBlock(Block block, IFormFile? ImageFile,bool delete)
        {
           
            if (delete)
            {
               

                //delete the block
                var existingBlockd = systemContext.Blocks.FirstOrDefault(x => x.Block_Id == block.Block_Id);
                if (existingBlockd != null)
                {
                    systemContext.Blocks.Remove(existingBlockd);
                    systemContext.SaveChanges();
                }

                return RedirectToAction("Update",new { Product_Id = block.Product_Id });
            }

            // Retrieve the block from the database
            var existingBlock = systemContext.Blocks.FirstOrDefault(x => x.Block_Id == block.Block_Id);
            if (ImageFile != null && ImageFile.Length > 0)
            {
                
                string uniqueFileName = GetUploadedFileName(ImageFile);
                if (uniqueFileName != null && uniqueFileName != "")
                {
                    block.Block_image = uniqueFileName;
                }
            }
            Console.WriteLine("..............................");
            if (existingBlock != null)
            {
                Console.WriteLine("entered");
                // Update the properties of the existing block
                existingBlock.Block_title = block.Block_title; 
                existingBlock.Block_description = block.Block_description;
                existingBlock.Block_image = block.Block_image;
                Console.WriteLine(block.Block_image);
                systemContext.SaveChanges();
            }

            return RedirectToAction("Update", new { Product_Id = block.Product_Id });
        }



        [HttpGet]
        public IActionResult UpdateStyle(int Style_Id)
        {

            var Style = systemContext.Styles.Where(x=>x.Style_Id==Style_Id).Include(x=>x.Style_images);
            return Json(Style.First());
        }
        [HttpPost]
        public IActionResult UpdateStyle(List<StyleWithFiles> styleWithFiles, bool delete)
        {
            
            Console.WriteLine("..............................");
            Console.WriteLine(styleWithFiles[0]?.files?.Count());
       
       

            if (delete)
            {


                //delete the style
                var existingStyled = systemContext.Styles.FirstOrDefault(x => x.Style_Id == styleWithFiles[0].style.Style_Id);
                if (existingStyled != null)
                {
                    systemContext.Styles.Remove(existingStyled);
                    systemContext.SaveChanges();
                }

                return RedirectToAction("Update", new { Product_Id = styleWithFiles[0].style.Product_Id });
            }

            // Retrieve the style from the database
            var existingStyle = systemContext.Styles.Include(s=>s.Style_images).FirstOrDefault(x => x.Style_Id == styleWithFiles[0].style.Style_Id);

            
            int i = 0;
            foreach(var file in styleWithFiles[0].files)
            {
               
                if (file.file != null && file.file.Length > 0)
                {
                   

                    string uniqueFileName = GetUploadedFileName(file.file);
                    if (!string.IsNullOrEmpty(uniqueFileName))
                    {
                        styleWithFiles[0].style.Style_images[i].Image_url = uniqueFileName;
                    }
                    
                }
                i++;
            }
           
         
            if (existingStyle != null)
            {

                // Update the properties of the existing Style
                existingStyle.Style_name = styleWithFiles[0].style.Style_name;
                existingStyle.Style_price= styleWithFiles[0].style.Style_price;

                existingStyle.Style_images = styleWithFiles[0].style.Style_images
             .Where(s => !string.IsNullOrEmpty(s.Image_url))
             .ToList();


                systemContext.SaveChanges();
            }

            return RedirectToAction("Update", new { Product_Id = styleWithFiles[0].style.Product_Id });
        }





        [HttpGet]
        public IActionResult AddQuantatity(int Product_Id)
        {

            return View();
        }

        [HttpPost]
        public IActionResult AddQuantatity(List<StyleSize>styleSizes)
        {

            return RedirectToAction("Products");
        }


        // DELETE the product
        [HttpGet]
		public IActionResult Delete(ProductIdAndName productIdAndName)
		{
            
			return View(productIdAndName);
		}

		[HttpPost]
		public IActionResult Delete(int productId)
		{
            // Find the product with the specified productId
            var productToRemove = systemContext.ProductList.FirstOrDefault(x => x.Product_Id == productId);

            if (productToRemove != null)
            {
                var imagesToDelete = systemContext.Images.Where(img => img.Style.Product.Product_Id == productId);
                systemContext.Images.RemoveRange(imagesToDelete);
                systemContext.SaveChanges();

                var stylesToDelete = systemContext.Styles.Where(s => s.Product.Product_Id == productId);
                systemContext.Styles.RemoveRange(stylesToDelete);
                systemContext.SaveChanges();

                var BlocksToDelete = systemContext.Blocks.Where(s => s.Product.Product_Id == productId);
                systemContext.Blocks.RemoveRange(BlocksToDelete);
                systemContext.SaveChanges();
                // Remove the product from the list
                systemContext.ProductList.Remove(productToRemove);
                // Save changes to the database
                systemContext.SaveChanges();
            }
            else
            {
                // Product with the specified ID was not found
                return NotFound();
            }
            CleanUnUsedImages();
            return RedirectToAction("Products");
		}

      
    }
    
}
