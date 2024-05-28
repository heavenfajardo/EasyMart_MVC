// Controllers/HomeController.cs
using Microsoft.AspNetCore.Mvc;

namespace EasyMart_MVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
