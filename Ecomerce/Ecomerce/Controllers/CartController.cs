using Ecomerce.Data;
using Ecomerce.Models;
using Ecomerce.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Ecomerce.Controllers
{
    public class CartController : Controller
    {
        private readonly SystemContext systemContext;
        public CartController(SystemContext _systemContext) { 
            this.systemContext = _systemContext;
        }
        List<ShopingCartItemViewModel> items;
        
        public IActionResult CartPage()
        {
            
            if (HttpContext.Session.GetString("CartItems") != null)
            {
                string json = HttpContext.Session.GetString("CartItems");
                items = JsonConvert.DeserializeObject<List<ShopingCartItemViewModel>>(json);
            }
           
            return View(items);
        }
        [HttpPost]
        public IActionResult AddToCart(ShopingCartItemViewModel newitem)
        {
            items = new List<ShopingCartItemViewModel>();
            newitem.Size =systemContext.Sizes.Find(newitem.sizeId).size;
            
            if (HttpContext.Session.GetString("CartItems")!=null)
            {
                string json = HttpContext.Session.GetString("CartItems");
                items = JsonConvert.DeserializeObject<List<ShopingCartItemViewModel>>(json);
            }

            items?.Add(newitem);
            string serializedItems = JsonConvert.SerializeObject(items);

            HttpContext.Session.SetString("CartItems", serializedItems);

            HttpContext.Session.SetString("ItemsCnt", items.Count().ToString());
            return Json(new { Success = true, Counter = items.Count() });
        }

        [HttpGet]
        public IActionResult CheckOut()
        {
            CheckOutViewModel model=new CheckOutViewModel();
                 if (HttpContext.Session.GetString("CartItems") != null)
            {
                string json = HttpContext.Session.GetString("CartItems");
                model.shopings = JsonConvert.DeserializeObject<List<ShopingCartItemViewModel>>(json);
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult CheckOut(CheckOutViewModel model)
        {
            
                // Create a new Customer object
                var customer = new Customer
                {
                    FirstName = model.customer.FirstName,
                    LastName = model.customer.LastName,
                    Country = model.customer.Country,
                    Address = model.customer.Address,
                    City = model.customer.City,
                    Governorate = model.customer.Governorate,
                    PostalCode = model.customer.PostalCode,
                    AdditionalAddressInfo = model.customer.AdditionalAddressInfo,
                    PhoneNumber = model.customer.PhoneNumber,
                    Email = model.customer.Email,
                    IsNewsOn = model.customer.IsNewsOn
                };

                // Add the customer to the database
                systemContext.customers.Add(customer);
                systemContext.SaveChanges();

                customer=systemContext.customers.OrderBy(c=>c.CustomerId).Last();
                //////////////
                var order = new Order
                {
                    OrderNumber = "01",
                    OrderDate = DateTime.Now, // Set the order date to the current date and time
                    CustomerId = customer.CustomerId // Assuming the customer ID is already available in the view model
                };

                // Add the order to the database
                systemContext.orders.Add(order);
                systemContext.SaveChanges();
                order=systemContext.orders.OrderBy(c=>c.OrderId).Last();
                foreach (var item in model.shopings)
                {
                    var orderDetail = new OrderDetails
                    {
                        OrderId = order.OrderId, // Assign the newly created order's ID
                        ProductId = item.productId, // Assuming ProductId is part of ShopingCartItemViewModel
                        StyleId = item.StyleId, // Assuming StyleId is part of ShopingCartItemViewModel
                        SizeId = item.sizeId, // Assuming SizeId is part of ShopingCartItemViewModel
                        Price = item.price, // Assuming Price is part of ShopingCartItemViewModel
                        Quantity = item.quantity, // Assuming Quantity is part of ShopingCartItemViewModel
                        Total = item.price * item.quantity, // Calculate the total price for this item
                        // Set other properties as needed
                    };

                    systemContext.orderDetails.Add(orderDetail);
                }

                // Save changes to the database
                systemContext.SaveChanges();
                // Redirect to another action or view
                return RedirectToAction("ThankYou"); // Example: redirect to a thank you page
            
            return View(model);
        }
        public IActionResult ThankYou()
        {
            HttpContext.Session.SetString("ItemsCnt","0");
            HttpContext.Session.SetString("CartItems", "");
            return View("CartPage");
        }

    }
}
