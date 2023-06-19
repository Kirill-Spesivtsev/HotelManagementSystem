using EmailService;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagementSystem.Controllers
{
    public class EmailController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEmailSender _emailSender;
        private readonly EmailConfiguration _emailConfig;

        public EmailController(ILogger<HomeController> logger, IEmailSender emailSender, EmailConfiguration emailConfig)
        {
            _logger = logger;
            _emailSender = emailSender;
            _emailConfig = emailConfig;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Send()
        {
            var message = new Message(new string[] { "ksby8819@gmail.com" }, "Smart Hotel Service", "Your email code", null);
            await _emailSender.SendEmailAsync(message);
            return View();
        }
    }
}
