using System;
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
    public class ServicePricesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ServicePricesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ServicePrices
        public async Task<IActionResult> Index()
        {
              return _context.ServicePrices != null ? 
                          View(await _context.ServicePrices.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.ServicePrices'  is null.");
        }

        // GET: ServicePrices/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ServicePrices == null)
            {
                return NotFound();
            }

            var servicePrice = await _context.ServicePrices
                .FirstOrDefaultAsync(m => m.ServiceId == id);
            if (servicePrice == null)
            {
                return NotFound();
            }

            return View(servicePrice);
        }

        // GET: ServicePrices/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ServicePrices/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ServiceId,Price")] ServicePrice servicePrice)
        {
            if (ModelState.IsValid)
            {
                _context.Add(servicePrice);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(servicePrice);
        }

        // GET: ServicePrices/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ServicePrices == null)
            {
                return NotFound();
            }

            var servicePrice = await _context.ServicePrices.FindAsync(id);
            if (servicePrice == null)
            {
                return NotFound();
            }
            return View(servicePrice);
        }

        // POST: ServicePrices/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ServiceId,Price")] ServicePrice servicePrice)
        {
            if (id != servicePrice.ServiceId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(servicePrice);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ServicePriceExists(servicePrice.ServiceId))
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
            return View(servicePrice);
        }

        // GET: ServicePrices/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ServicePrices == null)
            {
                return NotFound();
            }

            var servicePrice = await _context.ServicePrices
                .FirstOrDefaultAsync(m => m.ServiceId == id);
            if (servicePrice == null)
            {
                return NotFound();
            }

            return View(servicePrice);
        }

        // POST: ServicePrices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ServicePrices == null)
            {
                return Problem("Entity set 'ApplicationDbContext.ServicePrices'  is null.");
            }
            var servicePrice = await _context.ServicePrices.FindAsync(id);
            if (servicePrice != null)
            {
                _context.ServicePrices.Remove(servicePrice);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ServicePriceExists(int id)
        {
          return (_context.ServicePrices?.Any(e => e.ServiceId == id)).GetValueOrDefault();
        }
    }
}
