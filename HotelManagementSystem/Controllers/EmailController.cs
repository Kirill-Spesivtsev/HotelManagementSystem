using EmailService;
using HotelManagementSystem.Data;
using HotelManagementSystem.Entities;
using HotelManagementSystem.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagementSystem.Controllers
{
    [Authorize]
    public class EmailController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEmailSender _emailSender;
        private readonly EmailConfiguration _emailConfig;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;

        
        public EmailController(
            ILogger<HomeController> logger, IEmailSender emailSender, EmailConfiguration emailConfig, 
            UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        {
            _logger = logger;
            _emailSender = emailSender;
            _emailConfig = emailConfig;
            _context = context;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [NonAction]
        public async Task<IActionResult> Send(
                string[] recepientsArray, 
                string messageText,
                string mailTitle, 
                IFormFileCollection attachments = null)
        {
            var message = new EmailMessage
            (
                to: recepientsArray ?? new string[] { "ksby8819@gmail.com" }, 
                subject: mailTitle, 
                content: messageText, 
                attachments: attachments
            );

            await _emailSender.SendEmailAsync(message);
            return View();
        }

        [NonAction]
        public async Task<IActionResult> Send(string recepient, string mailTitle, string messageText)
        {
            return await Send(new string[] { recepient }, mailTitle, messageText);
        }

        public async Task<IActionResult> DistributeNewsletterToSubscribers()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> TestSend()
        {
            var message = new EmailMessage(new string[] { "ksby8819@gmail.com" }, "Smart Hotel Service", "Your email code...", null);
            await _emailSender.SendEmailAsync(message);
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> DistributeNewsletterToSubscribers(SimpleMessageViewModel message)
        {
            string[] addresses = _context.ApplicationUsers
                .Where(u => u.NewsletterSubscriber)
                .Select(u => u.Email).ToArray();
            _logger.LogError(string.Join(", ", addresses));

            var msg = new EmailMessage(addresses, message.Title ?? "Smart Hotel Service", message.Text, null);

            await _emailSender.SendEmailAsync(msg);

            return View();
        }

    }
}
