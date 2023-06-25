using EmailService;
using HotelManagementSystem.Data;
using HotelManagementSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Globalization;

namespace HotelManagementSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEmailSender _emailSender;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, IEmailSender emailSender, ApplicationDbContext context)
        {
            _logger = logger;
            _emailSender = emailSender;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public IActionResult Index(PreBookingViewModel preBooking)
        {
            //var dt = DateTime.ParseExact("6/27/2023 12:00:00 AM", "M/dd/yyyy hh:mm:ss tt", System.Globalization.CultureInfo.InvariantCulture);Console.WriteLine(dt.Date.ToString("dd.MM.yyyy"));
            var startStr = Request.Form["check-in"];
            var endStr = Request.Form["check-out"];
            var start = DateTime.ParseExact(startStr, "M/d/yyyy", CultureInfo.InvariantCulture);
            var end = DateTime.ParseExact(endStr, "M/d/yyyy", CultureInfo.InvariantCulture);
            var guests = int.Parse(Request.Form["guests"]);
            return RedirectToAction("ChooseApartment", "Bookings", 
                new{dateStart = start, dateEnd = end, guests = guests});
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}