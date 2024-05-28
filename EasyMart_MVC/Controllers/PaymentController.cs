using EasyMart_MVC.Models;
using Microsoft.AspNetCore.Mvc;

public class PaymentController : Controller
{
    // GET action to display the payment form
    [HttpGet]
    public IActionResult Payment(decimal totalAmount)
    {
        var paymentViewModel = new PaymentViewModel
        {
            TotalAmount = totalAmount
        };
        return View("Index", paymentViewModel); // Return the Index view instead of Payment
    }

    // POST action to handle form submission and generate the receipt
    [HttpPost]
    public IActionResult SubmitPayment(PaymentViewModel paymentViewModel)
    {
        if (ModelState.IsValid)
        {
            // Save payment details to the database or perform other actions

            // Create an instance of ReceiptModel using the payment details
            var receiptModel = new ReceiptModel
            {
                FullName = paymentViewModel.FullName,
                ContactNumber = paymentViewModel.ContactNumber,
                GcashName = paymentViewModel.GcashName,
                GcashNumber = paymentViewModel.GcashNumber,
                AmountPaid = paymentViewModel.TotalAmount
                // Add other properties as needed
            };

            // Redirect to the Index action in the ReceiptController and pass the receiptModel
            return RedirectToAction("Index", "Receipt", receiptModel);
        }

        // If ModelState is not valid, let it be handled by the view
        return View("Index", paymentViewModel);
    }
}
