﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HotelManagementSystem.Data;
using HotelManagementSystem.Models;

namespace HotelManagementSystem
{
    public class ApartmentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ApartmentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Apartments
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Apartments.Include(a => a.ApartmentCategory).Include(a => a.ApartmentDailyPrice).Include(a => a.ApartmentStatus).Include(a => a.EnrollmentTypeGuest);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Apartments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Apartments == null)
            {
                return NotFound();
            }

            var apartment = await _context.Apartments
                .Include(a => a.ApartmentCategory)
                .Include(a => a.ApartmentDailyPrice)
                .Include(a => a.ApartmentStatus)
                .Include(a => a.EnrollmentTypeGuest)
                .FirstOrDefaultAsync(m => m.ApartmentId == id);
            if (apartment == null)
            {
                return NotFound();
            }

            return View(apartment);
        }

        // GET: Apartments/Create
        public IActionResult Create()
        {
            ViewData["ApartmentCategoryId"] = new SelectList(_context.ApartmentCategories, "ApartmentCategoryId", "ApartmentCategoryId");
            ViewData["ApartmentDailyPriceId"] = new SelectList(_context.ApartmentDailyPrices, "ApartmentDailyPriceId", "ApartmentDailyPriceId");
            ViewData["ApartmentStatusId"] = new SelectList(_context.ApartmentStatuses, "ApartmentStatusId", "ApartmentStatusId");
            ViewData["ApartmentTypeId"] = new SelectList(_context.ApartmentTypes, "ApartmentTypeId", "ApartmentTypeId");
            return View();
        }

        // POST: Apartments/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ApartmentId,ApartmentName,IsFree,ImageUrl,ApartmentTypeId,ApartmentCategoryId,ApartmentStatusId,ApartmentDailyPriceId")] Apartment apartment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(apartment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ApartmentCategoryId"] = new SelectList(_context.ApartmentCategories, "ApartmentCategoryId", "ApartmentCategoryId", apartment.ApartmentCategoryId);
            ViewData["ApartmentDailyPriceId"] = new SelectList(_context.ApartmentDailyPrices, "ApartmentDailyPriceId", "ApartmentDailyPriceId", apartment.ApartmentDailyPriceId);
            ViewData["ApartmentStatusId"] = new SelectList(_context.ApartmentStatuses, "ApartmentStatusId", "ApartmentStatusId", apartment.ApartmentStatusId);
            ViewData["ApartmentTypeId"] = new SelectList(_context.ApartmentTypes, "ApartmentTypeId", "ApartmentTypeId", apartment.ApartmentTypeId);
            return View(apartment);
        }

        // GET: Apartments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Apartments == null)
            {
                return NotFound();
            }

            var apartment = await _context.Apartments.FindAsync(id);
            if (apartment == null)
            {
                return NotFound();
            }
            ViewData["ApartmentCategoryId"] = new SelectList(_context.ApartmentCategories, "ApartmentCategoryId", "ApartmentCategoryId", apartment.ApartmentCategoryId);
            ViewData["ApartmentDailyPriceId"] = new SelectList(_context.ApartmentDailyPrices, "ApartmentDailyPriceId", "ApartmentDailyPriceId", apartment.ApartmentDailyPriceId);
            ViewData["ApartmentStatusId"] = new SelectList(_context.ApartmentStatuses, "ApartmentStatusId", "ApartmentStatusId", apartment.ApartmentStatusId);
            ViewData["ApartmentTypeId"] = new SelectList(_context.ApartmentTypes, "ApartmentTypeId", "ApartmentTypeId", apartment.ApartmentTypeId);
            return View(apartment);
        }

        // POST: Apartments/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ApartmentId,ApartmentName,IsFree,ImageUrl,ApartmentTypeId,ApartmentCategoryId,ApartmentStatusId,ApartmentDailyPriceId")] Apartment apartment)
        {
            if (id != apartment.ApartmentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(apartment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ApartmentExists(apartment.ApartmentId))
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
            ViewData["ApartmentCategoryId"] = new SelectList(_context.ApartmentCategories, "ApartmentCategoryId", "ApartmentCategoryId", apartment.ApartmentCategoryId);
            ViewData["ApartmentDailyPriceId"] = new SelectList(_context.ApartmentDailyPrices, "ApartmentDailyPriceId", "ApartmentDailyPriceId", apartment.ApartmentDailyPriceId);
            ViewData["ApartmentStatusId"] = new SelectList(_context.ApartmentStatuses, "ApartmentStatusId", "ApartmentStatusId", apartment.ApartmentStatusId);
            ViewData["ApartmentTypeId"] = new SelectList(_context.ApartmentTypes, "ApartmentTypeId", "ApartmentTypeId", apartment.ApartmentTypeId);
            return View(apartment);
        }

        // GET: Apartments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Apartments == null)
            {
                return NotFound();
            }

            var apartment = await _context.Apartments
                .Include(a => a.ApartmentCategory)
                .Include(a => a.ApartmentDailyPrice)
                .Include(a => a.ApartmentStatus)
                .Include(a => a.EnrollmentTypeGuest)
                .FirstOrDefaultAsync(m => m.ApartmentId == id);
            if (apartment == null)
            {
                return NotFound();
            }

            return View(apartment);
        }

        // POST: Apartments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Apartments == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Apartments'  is null.");
            }
            var apartment = await _context.Apartments.FindAsync(id);
            if (apartment != null)
            {
                _context.Apartments.Remove(apartment);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ApartmentExists(int id)
        {
          return (_context.Apartments?.Any(e => e.ApartmentId == id)).GetValueOrDefault();
        }
    }
}
