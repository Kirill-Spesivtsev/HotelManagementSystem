using HotelManagementSystem.Data;
using HotelManagementSystem.Entities;
using HotelManagementSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace HotelManagementSystem.Controllers
{
    [Authorize]
    public class StatisticsController : Controller
    {

        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public StatisticsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        
        public async Task<ActionResult> Index()
        {
            var userId = _userManager.GetUserId(User);
            DateTime StartDate = DateTime.Today.AddDays(-365);
            DateTime EndDate = DateTime.Today;

            var SelectedTransactions = _context.Enrollments
                .Where(y => y.DateStart >= StartDate && y.DateStart <= EndDate)
                .ToList();

            double totalIncome = 0;//SelectedTransactions

            ViewBag.TotalIncome = totalIncome.ToString("F") + " $";


            CultureInfo culture = CultureInfo.CreateSpecificCulture("en-US");
            culture.NumberFormat.CurrencyNegativePattern = 1;




            List<PlotData> incomeStatistics = SelectedTransactions
                .GroupBy(j => j.DateStart)
                .Select(k => new PlotData()
                {
                    day = k.First().DateStart.ToString("dd-MM-yyyy"),
                    income = k.Sum(l => l.Apartment.DailyPrice)
                })
                .ToList();


            string[] LastData = Enumerable.Range(0, 365)
                .Select(i => StartDate.AddDays(i).ToString("dd-MM-yyyy"))
                .ToArray();

            ViewBag.SplineChartData = 
                    from day in LastData
                    join income in incomeStatistics on day equals income.day into dayIncomeJoined
                    from income in dayIncomeJoined.DefaultIfEmpty()
                    select new
                    {
                        day = day,
                        income = income == null ? 0 : income.income,
                    };

            return View();
        }
    }

    public class PlotData
    {
        public string day;
        public double income;

    }

        
}
