using HotelManagementSystem.Data;
using HotelManagementSystem.Entities;
using HotelManagementSystem.ViewModels;
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

            List<PlotData> dayProfits = new List<PlotData>(365);
            for(int i = 0;i<365;i++)
            {
                dayProfits[i].day = StartDate.AddDays(i).ToString("dd-MM-yyyy");
                dayProfits[i].income = 0;
            }
            foreach (var enr in _context.Enrollments)
            {
                DateTime cDate;
                for (int i = 0; i < (enr.DateEnd - enr.DateStart).Days; i++)
                {
                    cDate = enr.DateStart.AddDays(i);
                    if(cDate >= StartDate)
                    dayProfits.Where(e => e.day == cDate.ToString("dd-MM-yyyy"))
                            .ToList().ForEach(q => q.day += 1);
                }
            } 
            ViewBag.SplineChartData = dayProfits;

            ViewBag.MostProfitableRooms = _context.Enrollments
                .GroupBy(r=>r.Apartment)
                .Select(group => new 
                {
                    Key = group.Key, 
                    Value = group.Sum(q => q.Apartment.DailyPrice * (q.DateEnd - q.DateStart).TotalDays)
                });

            return View();
        }
    }

    public class PlotData
    {
        public string day;
        public double income;

    }

        
}
