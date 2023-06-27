using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HotelManagementSystem.Data;
using HotelManagementSystem.Models;
using Microsoft.AspNetCore.Identity;
using HotelManagementSystem.Entities;
using Microsoft.AspNetCore.Authorization;

namespace HotelManagementSystem
{
    [Authorize]
    public class BookingsController : Controller
    {
        private readonly ILogger<BookingsController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public BookingsController(
            ApplicationDbContext context, 
            UserManager<ApplicationUser> userManager, 
            ILogger<BookingsController> logger)
        {
            _context = context;
            _userManager = userManager;
            _logger = logger;
        }

        // GET: Bookings
        public async Task<IActionResult> Index1()
        {
            var applicationDbContext = _context.Enrollments;
            return View(await applicationDbContext.ToListAsync());
        }

        public async Task<IActionResult> ChooseApartment(DateTime dateStart, DateTime dateEnd, int guests)
        {
            //var validApartments = _context.Apartments.Include(q => q.ApartmentType);
            
            var apartments = _context.Apartments
                .Include(q => q.ApartmentType)
                .Where(q => q.ApartmentType.TypeName == guests.ToString())
                .ToList();
                
            var invalidApartments = _context.Enrollments
                    .Include(q => q.Apartment)
                    .ThenInclude(q => q.ApartmentType)
                .Where(q => q.Apartment.ApartmentType.TypeName == guests.ToString())
                .GroupBy(a => a.ApartmentId)
                .Select(g => g.OrderBy(a => a.DateEnd).Last())
                .ToList()
                .Where(apd => dateStart <= apd.DateEnd)
                .Select(ap => ap.Apartment)
                .ToList();

            ViewBag.FilteredApartments = apartments.Except(invalidApartments).ToList();
 
            return View("ChooseApartment", new PreBookingViewModel{DateStart = dateStart, DateEnd = dateEnd, AdultsNumber = guests});
        }

        // POST: Bookings/ChooseApartment
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChooseApartment(PreBookingViewModel preBooking)
        {
            preBooking.ApartmentId = Guid.Parse(Request.Form["apartmentId"]);
            ViewBag.preBooking = preBooking;
            
            return RedirectToAction("Create", new 
            {
                dateStart = preBooking.DateStart,
                dateEnd = preBooking.DateEnd,
                adultsNumber = preBooking.AdultsNumber,
                apartmentId = preBooking.ApartmentId.Value 
            });
        }

        // GET: Bookings/Create
        public async Task<IActionResult> Create(DateTime dateStart,DateTime dateEnd, int adultsNumber, Guid apartmentId )
        {
            ViewData["EnrollmentTypeId"] = new SelectList(_context.EnrollmentTypes, "EnrollmentTypeId", "Name");
            ViewData["GenderId"] = new SelectList(_context.Genders, "GenderId", "GenderName");
            //ViewBag.DateStart = dateStart;
            //ViewBag.DateEnd = dateEnd;
            BookingViewModel booking = new BookingViewModel
            {
                DateStart = dateStart,
                DateEnd = dateEnd,
                AdultsNumber = adultsNumber,
                ApartmentId = apartmentId
            };

            return View(booking);
        }

        // POST: Bookings/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( [Bind] BookingViewModel bookingViewModel)
        {
            var user = await _userManager.GetUserAsync(User);
            ModelState.Clear();
            if (ModelState.IsValid)
            {
                var enrollment = new Enrollment
                {
                    EnrollmentId = Guid.NewGuid(),
                    DateStart = bookingViewModel.DateStart,
                    DateEnd = bookingViewModel.DateEnd,
                    AdultsNumber = bookingViewModel.AdultsNumber,
                    ChildrenNumber = bookingViewModel.ChildrenNumber,
                    BookingOnly = true,
                    PrePaid = true,
                    ApartmentId = bookingViewModel.ApartmentId,
                    EnrollmentTypeId = _context.EnrollmentTypes.FirstOrDefault().EnrollmentTypeId,
                    EnrollmentStatusId = _context.EnrollmentStatuses.FirstOrDefault().EnrollmentStatusId
                };
                var guest = new Guest
                {
                    GuestId = Guid.NewGuid(),
                    FirstName = bookingViewModel.FirstName,
                    LastName = bookingViewModel.LastName,
                    IdNumber = bookingViewModel.IdNumber,
                    Country = bookingViewModel.Country,
                    BirthDate = bookingViewModel.BirthDate,
                    GenderId = bookingViewModel.GenderId,
                };
                var eg = new EnrollmentGuest
                {
                    EnrollmentId = enrollment.EnrollmentId,
                    GuestId = guest.GuestId,
                };
                user.User = guest.GuestId.ToString();
                _context.Add(enrollment);
                _context.Add(guest);
                _context.Add(eg);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index","Home");
            }
           ViewData["EnrollmentTypeId"] = new SelectList(
                    _context.EnrollmentTypes, "EnrollmentTypeId", "Name", bookingViewModel.EnrollmentTypeId);
            ViewData["GenderId"] = new SelectList(
                    _context.Genders, "GenderId", "GenderName", bookingViewModel.GenderId);
            return View(bookingViewModel);
        }

        // GET: Bookings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {

            var enr = await _context.Enrollments.FindAsync(id);
            if (enr == null)
            {
                return NotFound();
            }

            ViewData["EnrollmentTypeId"] = new SelectList(
                    _context.EnrollmentTypes, "EnrollmentTypeId", "Name", enr.EnrollmentTypeId);

            return View(enr);
        }

        // POST: Bookings/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("GuestId,Discont,FirtstName,LastName,IdNumber,Country,BirthDate,GenderId,DateStart,DateEnd,AdultsNumber,ChildrenNumber,BookingOnly,PrePaid,ApartmentId,EnrollmentTypeId")] Enrollment enr)
        {
            if (id != enr.EnrollmentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {

                    _context.Update(enr);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookingViewModelExists(enr.EnrollmentId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ApartmentId"] = new SelectList(
                    _context.Apartments, "ApartmentId", "ApartmentName", enr.ApartmentId);
            ViewData["EnrollmentTypeId"] = new SelectList(
                    _context.EnrollmentTypes, "EnrollmentTypeId", "Name", enr.EnrollmentTypeId);
            return View(enr);
        }

        // GET: Bookings/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.Enrollments == null)
            {
                return NotFound();
            }

            var enr = await _context.Enrollments
                .Include(b => b.Apartment)
                .Include(b => b.EnrollmentType)
                .FirstOrDefaultAsync(m => m.EnrollmentId == id);
            if (enr == null)
            {
                return NotFound();
            }

            return View(enr);
        }

        // POST: Bookings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Enrollments == null)
            {
                return Problem("Entity set 'ApplicationDbContext.BookingViewModel'  is null.");
            }
            var enr = await _context.Enrollments.FindAsync(id);
            if (enr != null)
            {
                _context.Enrollments.Remove(enr);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookingViewModelExists(Guid id)
        {
          return (_context.Enrollments?.Any(e => e.EnrollmentId == id)).GetValueOrDefault();
        }
    }
}
