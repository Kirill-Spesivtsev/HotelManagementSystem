using Microsoft.AspNetCore.Mvc;

namespace HotelManagementSystem.Controllers
{
    public class RedirectController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Management()
        {
            return View();
        }
    }
}
