namespace EasyMart_MVC.Models
{
    public class CheckoutViewModel
    {
        public string OrderId { get; set; }
        public decimal TotalAmount { get; set; }
        public List<CartItem> CartItems { get; set; }
    }
}
