using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HotelManagementSystem.Data;
using HotelManagementSystem.Models;
using Microsoft.AspNetCore.Authorization;

namespace HotelManagementSystem.Controllers
{
    [Authorize]
    public class ApartmentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ApartmentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Apartment
        public async Task<IActionResult> Index()
        {
            var aplist = _context.Apartments
                .Include(a => a.ApartmentCategory)
                .Include(a => a.ApartmentStatus)
                .Include(a => a.ApartmentType);

            return View(await aplist.OrderBy(t => t.ApartmentName).ToListAsync());
        }

        // GET: Apartment/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.Apartments == null)
            {
                return NotFound();
            }

            var apartment = await _context.Apartments
                .Include(a => a.ApartmentCategory)
                .Include(a => a.ApartmentStatus)
                .Include(a => a.ApartmentType)
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
            ViewData["ApartmentCategoryId"] = new SelectList(_context.ApartmentCategories, "ApartmentCategoryId", "CategoryName");
            ViewData["ApartmentStatusId"] = new SelectList(_context.ApartmentStatuses, "ApartmentStatusId", "StatusName");
            ViewData["ApartmentTypeId"] = new SelectList(_context.ApartmentTypes, "ApartmentTypeId", "TypeName");
            return View();
        }

        // POST: Apartments/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ApartmentId,ApartmentName,ApartmentTitle,Description,ImageUrl,DailyPrice,ApartmentTypeId,ApartmentCategoryId,ApartmentStatusId")] Apartment apartment)
        {
            ModelState.Clear();
            if (ModelState.IsValid)
            {
                _context.Add(apartment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ApartmentCategoryId"] = new SelectList(_context.ApartmentCategories, "ApartmentCategoryId", "CategoryName", apartment.ApartmentCategoryId);
            ViewData["ApartmentStatusId"] = new SelectList(_context.ApartmentStatuses, "ApartmentStatusId", "StatusName", apartment.ApartmentStatusId);
            ViewData["ApartmentTypeId"] = new SelectList(_context.ApartmentTypes, "ApartmentTypeId", "TypeName", apartment.ApartmentTypeId);
            return View(apartment);
        }

        // GET: Apartments/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
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
            ViewData["ApartmentCategoryId"] = new SelectList(_context.ApartmentCategories, "ApartmentCategoryId", "CategoryName", apartment.ApartmentCategoryId);
            ViewData["ApartmentStatusId"] = new SelectList(_context.ApartmentStatuses, "ApartmentStatusId", "StatusName", apartment.ApartmentStatusId);
            ViewData["ApartmentTypeId"] = new SelectList(_context.ApartmentTypes, "ApartmentTypeId", "TypeName", apartment.ApartmentTypeId);
            return View(apartment);
        }

        // POST: Apartments/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid? id, [Bind("ApartmentId,ApartmentName,ApartmentTitle,Description,ImageUrl,DailyPrice,ApartmentTypeId,ApartmentCategoryId,ApartmentStatusId")] Apartment apartment)
        {
            if (id != apartment.ApartmentId)
            {
                return NotFound();
            }

            ModelState.Clear();
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
            ViewData["ApartmentCategoryId"] = new SelectList(_context.ApartmentCategories, "ApartmentCategoryId", "CategoryName", apartment.ApartmentCategoryId);
            ViewData["ApartmentStatusId"] = new SelectList(_context.ApartmentStatuses, "ApartmentStatusId", "StatusName", apartment.ApartmentStatusId);
            ViewData["ApartmentTypeId"] = new SelectList(_context.ApartmentTypes, "ApartmentTypeId", "TypeName", apartment.ApartmentTypeId);
            return View(apartment);
        }

        // GET: Apartments/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.Apartments == null)
            {
                return NotFound();
            }

            var apartment = await _context.Apartments
                .Include(a => a.ApartmentCategory)
                .Include(a => a.ApartmentStatus)
                .Include(a => a.ApartmentType)
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
                return Problem("Entity set 'ApplicationDbContext.Apartments' is null.");
            }
            var apartment = await _context.Apartments.FindAsync(id);
            if (apartment != null)
            {
                _context.Apartments.Remove(apartment);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ApartmentExists(Guid id)
        {
          return (_context.Apartments?.Any(e => e.ApartmentId == id)).GetValueOrDefault();
        }
    }
}
