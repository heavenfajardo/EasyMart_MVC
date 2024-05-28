using EasyMart_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace EasyMart_MVC.Controllers
{
    public class CartController : Controller
    {
        // GET: /Cart
        public IActionResult Index()
        {
            var cartViewModel = new CartViewModel
            {
                CartItems = MenuController.GetCartItems()
            };
            return View(cartViewModel);
        }

        // POST: /Cart/IncreaseQuantity
        [HttpPost]
        public IActionResult IncreaseQuantity(string productName)
        {
            var cartItem = MenuController.GetCartItems().FirstOrDefault(item => item.ProductName == productName);
            if (cartItem != null)
            {
                cartItem.Quantity++;
            }
            return RedirectToAction("Index");
        }

        // POST: /Cart/DecreaseQuantity
        [HttpPost]
        public IActionResult DecreaseQuantity(string productName)
        {
            var cartItem = MenuController.GetCartItems().FirstOrDefault(item => item.ProductName == productName);
            if (cartItem != null && cartItem.Quantity > 1)
            {
                cartItem.Quantity--;
            }
            return RedirectToAction("Index");
        }

        // POST: /Cart/RemoveItem
        [HttpPost]
        public IActionResult RemoveItem(string productName)
        {
            var cartItem = MenuController.GetCartItems().FirstOrDefault(item => item.ProductName == productName);
            if (cartItem != null)
            {
                MenuController.GetCartItems().Remove(cartItem);
            }
            return RedirectToAction("Index");
        }

        // POST: /Cart/AddToCart
        [HttpPost]
        public IActionResult AddToCart(int itemId)
        {
            var menuItem = GetMenuItemById(itemId);
            if (menuItem != null)
            {
                var existingCartItem = MenuController.GetCartItems().FirstOrDefault(c => c.ProductName == menuItem.Name);
                if (existingCartItem != null)
                {
                    existingCartItem.Quantity++;
                }
                else
                {
                    var cartItem = new CartItem
                    {
                        ProductName = menuItem.Name,
                        Price = menuItem.Price,
                        Quantity = 1,
                        ImageUrl = menuItem.ImageUrl
                    };
                    MenuController.GetCartItems().Add(cartItem);
                }
            }
            return RedirectToAction("Index");
        }

        // POST: /Cart/PayNow
        [HttpPost]
        public IActionResult PayNow()
        {
            // Calculate total price from cart items
            decimal totalAmount = MenuController.GetCartItems().Sum(item => item.Price * item.Quantity);

            // Redirect to the Payment action in the PaymentController, passing the total price
            return RedirectToAction("Payment", "Payment", new { totalAmount });
        }

        // GET: /Cart/Payment
        public IActionResult Payment()
        {
            // Calculate total amount from cart items
            decimal totalAmount = MenuController.GetCartItems().Sum(item => item.Price * item.Quantity);

            // Pass the total amount to the Payment view
            var paymentViewModel = new PaymentViewModel
            {
                TotalAmount = totalAmount
            };

            return View("Payment", paymentViewModel);
        }





        private MenuItem GetMenuItemById(int itemId)
        {
            var menuItems = new List<MenuItem>
            {
              new MenuItem { Id = 1, Name = "Orange", Price = 20m, ImageUrl = "/images/orange.jpg" },
                new MenuItem { Id = 2, Name = "Sandwich", Price = 150m, ImageUrl = "/images/sandwich.jpg" },
                new MenuItem { Id = 3, Name = "Apples", Price = 100m, ImageUrl = "/images/apples.jpg" },
                new MenuItem { Id = 4, Name = "Strawberry", Price = 150m, ImageUrl = "/images/strawberry.jpg" },
                new MenuItem { Id = 5, Name = "Mango", Price = 10m, ImageUrl = "/images/mango.jpg" },
                new MenuItem { Id = 6, Name = "Grapes", Price = 10m, ImageUrl = "/images/grapes.jpg" }
            };
            return menuItems.Find(item => item.Id == itemId);
        }
    }
}
