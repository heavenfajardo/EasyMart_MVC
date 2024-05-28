namespace EasyMart_MVC.Models
{
    public class PaymentViewModel
    {
        public decimal TotalAmount { get; set; }
        public string FullName { get; set; }
        public string ContactNumber { get; set; }
        public string GcashName { get; set; }
        public string GcashNumber { get; set; }
        public decimal CartTotalPrice { get; set; } // Add this property
    }
}
