// CartService.cs
using System.Collections.Generic;
using EasyMart_MVC.Models;

namespace EasyMart_MVC.Services
{
    public class CartService
    {
        private List<CartItem> cartItems = new List<CartItem>();

        public void AddToCart(CartItem cartItem)
        {
            cartItems.Add(cartItem);
        }

        public List<CartItem> GetCartItems()
        {
            return cartItems;
        }
    }
}
