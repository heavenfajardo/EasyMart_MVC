using EasyMart_MVC.Models;
using Microsoft.AspNetCore.Mvc;

public class ReceiptController : Controller
{
    // GET action to display the receipt
    public IActionResult Index(ReceiptModel receiptModel)
    {
        return View(receiptModel);
    }
}
