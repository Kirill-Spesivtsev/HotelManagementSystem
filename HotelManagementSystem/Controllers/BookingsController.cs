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

namespace HotelManagementSystem
{
    public class BookingsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public BookingsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Bookings
        public async Task<IActionResult> Index1()
        {
            var applicationDbContext = _context.Enrollments;
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Bookings/Create
        public IActionResult Create()
        {
            ViewData["ApartmentId"] = new SelectList(_context.Apartments, "ApartmentId", "ApartmentName");
            ViewData["EnrollmentTypeId"] = new SelectList(_context.EnrollmentTypes, "EnrollmentTypeId", "Name");
            ViewData["GenderId"] = new SelectList(_context.Genders, "GenderId", "GenderName");
            return View();
        }

        // POST: Bookings/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GuestId,Discont,FirtstName,LastName,IdNumber,Country,BirthDate,GenderId,DateStart,DateEnd,AdultsNumber,ChildrenNumber,BookingOnly,PrePaid,ApartmentId,EnrollmentTypeId")] BookingViewModel bookingViewModel)
        {
            var userId = _userManager.GetUserId(User);
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
                    ApartmentId = _context.Apartments.FirstOrDefault().ApartmentId,
                    EnrollmentTypeId = _context.EnrollmentTypes.FirstOrDefault().EnrollmentTypeId,
                    EnrollmentStatusId = _context.EnrollmentStatuses.FirstOrDefault().EnrollmentStatusId
                };
                var guest = new Guest
                {
                    GuestId = Guid.NewGuid(),
                    FirtstName = bookingViewModel.FirtstName,
                    LastName = bookingViewModel.LastName,
                    IdNumber = bookingViewModel.IdNumber,
                    Country = bookingViewModel.Country,
                    User = userId,
                    BirthDate = bookingViewModel.BirthDate,
                    GenderId = bookingViewModel.GenderId,
                };
                var eg = new EnrollmentGuest
                {
                    EnrollmentId = enrollment.EnrollmentId,
                    GuestId = guest.GuestId,
                };

                _context.Add(enrollment);
                _context.Add(guest);
                _context.Add(eg);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ApartmentId"] = new SelectList(
                    _context.Apartments, "ApartmentId", "ApartmentName", bookingViewModel.ApartmentId);
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
            ViewData["ApartmentId"] = new SelectList(
                    _context.Apartments, "ApartmentId", "ApartmentName", enr.ApartmentId);
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
