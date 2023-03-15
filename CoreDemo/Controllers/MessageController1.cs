using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{
    public class MessageController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
