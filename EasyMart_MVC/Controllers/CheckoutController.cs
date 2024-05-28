using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using EasyMart_MVC.Models;

public class CheckoutController : Controller
{
    public IActionResult Index()
    {
        var model = new CheckoutViewModel
        {
            CartItems = new List<CartItem>
            {
                new CartItem { ProductName = "Product 1", Quantity = 1, Price = 10.00m },
                new CartItem { ProductName = "Product 2", Quantity = 2, Price = 20.00m }
            },
            TotalAmount = 50.00m
        };
        return View(model);
    }

    [HttpPost]
    public IActionResult Confirm(CheckoutViewModel model)
    {
        if (ModelState.IsValid)
        {
            // Process the order
            // Redirect to order confirmation or payment page
        }

        return View("Index", model);
    }
}
