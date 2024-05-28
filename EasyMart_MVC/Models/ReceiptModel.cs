namespace EasyMart_MVC.Models
{
    public class ReceiptModel
    {
        public string FullName { get; set; }
        public string ContactNumber { get; set; }
        public string GcashName { get; set; }
        public string GcashNumber { get; set; }
        public decimal AmountPaid { get; set; }
        // Add other properties as needed
    }
}
