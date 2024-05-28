using Microsoft.AspNetCore.Mvc;
using EasyMart_MVC.Models;
using System.Collections.Generic;

namespace EasyMart_MVC.Controllers
{
    public class MenuController : Controller
    {
        private static List<CartItem> cartItems = new List<CartItem>();

        // GET: /Menu
        public IActionResult Index()
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
            return View(menuItems);
        }

        // Provide a method for CartController to access cartItems
        public static List<CartItem> GetCartItems()
        {
            return cartItems;
        }
    }
}
